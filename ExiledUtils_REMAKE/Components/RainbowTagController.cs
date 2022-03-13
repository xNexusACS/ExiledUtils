using System;
using UnityEngine;
using MEC;
using System.Collections.Generic;
using Exiled.API.Features;

namespace ExiledUtils_REMAKE.Components
{
    public class RainbowTagController : MonoBehaviour
    {
		public string[] Colors
		{
			get
			{
				return this.colors ?? Array.Empty<string>();
			}
			set
			{
				this.colors = (value ?? Array.Empty<string>());
				this.position = 0;
			}
		}
		public float Interval
		{
			get
			{
				return this.interval;
			}
			set
			{
				this.interval = value;
				this.intervalInFrames = Mathf.CeilToInt(value) * 50;
			}
		}
		private void Awake()
		{
			this.player = Player.Get(base.gameObject);
		}
		private void Start()
		{
			this.coroutineHandle = Timing.RunCoroutine(MECExtensionMethods2.CancelWith<RainbowTagController>(MECExtensionMethods2.CancelWith(this.UpdateColor(), this.player.GameObject), this));
		}
		private void OnDestroy()
		{
			Timing.KillCoroutines(new CoroutineHandle[]
			{
				this.coroutineHandle
			});
		}
		private string RollNext()
		{
			int num = this.position + 1;
			this.position = num;
			if (num >= this.colors.Length)
			{
				this.position = 0;
			}
			if (this.colors.Length == 0)
			{
				return string.Empty;
			}
			return this.colors[this.position];
		}
		private IEnumerator<float> UpdateColor()
		{
			for (; ; )
			{
				int num;
				for (int z = 0; z < this.intervalInFrames; z = num + 1)
				{
					yield return 0f;
					num = z;
				}
				string text = this.RollNext();
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				this.player.RankColor = text;
			}
			UnityEngine.Object.Destroy(this);
			yield break;
		}
		private Player player;
		private int position;
		private float interval;
		private CoroutineHandle coroutineHandle;
		private string[] colors;
		private int intervalInFrames;
	}
}

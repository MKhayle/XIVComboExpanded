﻿using System;
using System.Runtime.CompilerServices;

namespace XIVCombo {
	[AttributeUsage(AttributeTargets.Field)]
	internal class OrderedAttribute: Attribute {
		public int Order { get; }
		internal OrderedAttribute([CallerLineNumber] int order = 0) {
			this.Order = order;
		}
	}
}

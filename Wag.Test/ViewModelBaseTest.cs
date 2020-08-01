using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Wag.Domain;

namespace Wag.Test
{
	public class ViewModelBaseTest : ViewModelBase
	{
		[Test]
		public void OnPropertyChanged_ValueChanged_TriggersEvent()
		{
			bool thePropertyChanged = false;
			PropertyChanged += ( a, b ) => thePropertyChanged = true;

			ValidProperty = !ValidProperty;

			Assert.That( thePropertyChanged, Is.True );
		}

		[Test]
		public void OnPropertyChanged_WithInvalidName_ThrowsInDebugMode()
		{
			void Actor()
			{
				InvalidProperty = true;
			}

#if DEBUG
			Assert.That( Actor, Throws.Exception );
#else
			Assert.That( Actor, Throws.Nothing );
#endif
		}

		private bool myInvalidProperty;

		public bool InvalidProperty
		{
			get => myInvalidProperty;
			set
			{
				myInvalidProperty = value;
				OnPropertyChanged( "invalid by intention" );
			}
		}

		[Test]
		public void OnPropertyChanged_WithValidName_DoesNotThrow()
		{
			void Actor()
			{
				ValidProperty = true;
			}

			Assert.That( Actor, Throws.Nothing );
		}

		private bool myValidProperty;

		public bool ValidProperty
		{
			get => myValidProperty;
			set
			{
				myValidProperty = value;
				OnPropertyChanged( nameof( ValidProperty ) );
			}
		}
	}
}

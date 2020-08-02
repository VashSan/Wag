using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wag.Domain;

namespace Wag.Test.Domain
{
	public class RelayCommandTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Constructor_WithNullAction_Throws()
		{
			// Arrange & Act
			static void Actor()
			{
				// ReSharper disable once ObjectCreationAsStatement
				new RelayCommand( null );
			}

			// Assert
			Assert.That( (Action)Actor, Throws.ArgumentNullException, "The relay command should not accept a null action" );
		}

		[TestCaseSource( nameof( CanExecuteFunctionsThatReturnTrue ) )]
		public void CanExecute_Invocations_ReturnTrue( Func<object, bool> canExecute )
		{
			// Arrange
			var command = new RelayCommand( ( o ) => { }, canExecute );

			// Act
			var result = command.CanExecute( null );

			// Assert
			Assert.That( result, Is.True );
		}

		public static IEnumerable<TestCaseData> CanExecuteFunctionsThatReturnTrue
		{
			get
			{
				yield return new TestCaseData( null );
				yield return new TestCaseData( (Func<object, bool>)(( o ) => true) );
			}
		}

		[Test]
		public void CanExecute_Invocations_ReturnFalse()
		{
			// Arrange
			static bool CanExecute( object o ) => false;
			var command = new RelayCommand( ( o ) => { }, CanExecute );

			// Act
			var result = command.CanExecute( null );

			// Assert
			Assert.That( result, Is.False );
		}

		[Test]
		public void Execute_Invocation_PerformsAction()
		{
			// Arrange
			var executed = false;
			void Execute( object o ) => executed = true;
			var command = new RelayCommand( Execute );

			// Act
			command.Execute( null );

			// Assert
			Assert.That( executed, Is.True );
		}
	}
}
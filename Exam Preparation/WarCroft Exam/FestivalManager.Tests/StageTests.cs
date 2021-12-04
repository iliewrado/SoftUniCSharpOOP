// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private List<Song> songs;
		private List<Performer> performers;
		private Performer justin = new Performer("Justin", "Biber", 17);
		private Performer lili = new Performer("Lili", "Ivanova", 100);
		private Song vetrove = new Song("Vetrove", new TimeSpan(0, 5, 55));
		private Song sorry = new Song("Sorry", new TimeSpan(0, 0, 20));
		private Stage stage;

		[SetUp]
	    public void Setup()
	    {
			stage = new Stage();
			performers = new List<Performer>();
			this.songs = new List<Song>();
		}

		[Test]
		public void CtorTest()
        {
			Assert.IsNotNull(stage);
			Assert.AreEqual(0, stage.Performers.Count);
		}


		[Test]
		public void AddCorrectPerformer()
        {
			stage.AddPerformer(lili);
			Assert.AreEqual(stage.Performers.Count, 1);
			Assert.AreEqual(lili, stage.Performers.ToArray()[0]);
        }

		[Test]
		public void ValidateValueTest()
        {
			Performer performer = null;
			Assert.Throws<ArgumentNullException>
				(() => stage.AddPerformer(performer));
        }

		[Test]
		public void ListOfSongsTest()
        {
			this.songs.Add(vetrove);
			stage.AddSong(vetrove);
			List<Song> songs = typeof(Stage)
				.GetFields(System.Reflection.BindingFlags.Instance
				| System.Reflection.BindingFlags.NonPublic)
				.FirstOrDefault(x => x.Name == "Songs")
				.GetValue(this.stage) as List<Song>;
			Assert.AreEqual(songs, this.songs);
        }

		[Test]
		public void UnderAgePerformerException()
        {
			Assert.Throws<ArgumentException>
				(() => stage.AddPerformer(justin));
        }

		[Test]
		public void InvalidSong()
        {
			Song song = null;
			Assert.Throws<ArgumentNullException>
				(() => stage.AddSong(song));
        }

		[Test]
		public void TooShortSongException()
        {
			Assert.Throws<ArgumentException>
				(() => stage.AddSong(sorry));
        }

		[Test]
		public void AddCorrectSongToPerformer()
        {
			stage.AddPerformer(lili);
			stage.AddSong(vetrove);
			string message = stage.AddSongToPerformer("Vetrove", "Lili Ivanova");
			Assert.AreEqual(lili.SongList.Count, 1);
			Assert.AreEqual(stage.AddSongToPerformer("Vetrove", "Lili Ivanova"), message);
        }

		[Test]
		public void PlayTest()
        {
			stage.AddPerformer(lili);
			stage.AddSong(vetrove);
			stage.AddSongToPerformer("Vetrove", "Lili Ivanova");
			Assert.AreEqual(stage.Play(), "1 performers played 3 songs");
        }

		[Test]
		public void AddSongToNonExitPerformerThrowException()
        {
			stage.AddPerformer(lili);
			stage.AddSong(vetrove);
			Assert.Throws<ArgumentException>
				(() => stage.AddSongToPerformer("Vetrove", "Justin Biber"));
        }

		[Test]
		public void AddNotExsistSongToPerformerThrowException()
        {
			stage.AddSong(vetrove);
			stage.AddPerformer(lili);
			Assert.Throws<ArgumentException>
				(() => stage.AddSongToPerformer("Sorry", "Lili Ivanova"));
        }
	}
}
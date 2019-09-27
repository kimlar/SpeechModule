using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB_voicespeaker.Audio;

namespace UTB_voicespeaker.Synthesizer
{
	class SpeechMacroProcessor
	{
		// TODO: Surround with try-catch
		public void Process(Language lang, string say)
		{
			Speaker sp = new Speaker(lang);

			if (say.Contains("@phonetic"))
				sp.UseSSML = true;

			// Speech Macro Processor
			int spPos = 0;
			for (int i = 0; i < say.Length; i++)
			{
				if (say[i] == '@')
				{
					// @pacman
					if (say.Substring(i).StartsWith("@pacman"))
					{
						sp.Speak(say.Substring(spPos, i - spPos));
						spPos = i + "@pacman".Length;

						AudioPlayer ap = new AudioPlayer("Pacman.wav");
						ap.Play();
					}
					// @extra
					if (say.Substring(i).StartsWith("@extra"))
					{
						sp.Speak(say.Substring(spPos, i - spPos));
						spPos = i + "@extra".Length;

						AudioPlayer ap = new AudioPlayer("Mario Extra Life.wav");
						ap.Play();
					}
					// @jump
					if (say.Substring(i).StartsWith("@jump"))
					{
						sp.Speak(say.Substring(spPos, i - spPos));
						spPos = i + "@jump".Length;

						AudioPlayer ap = new AudioPlayer("Mario Jump.wav");
						ap.Play();
					}
					// @bubblegum
					if (say.Substring(i).StartsWith("@bubblegum"))
					{
						sp.Speak(say.Substring(spPos, i - spPos));
						spPos = i + "@bubblegum".Length;

						AudioPlayer ap = new AudioPlayer("Out Of Bubble Gum.wav");
						ap.Play();
					}
					// @phonetic(...)
					if (say.Substring(i).StartsWith("@phonetic("))
					{					
						sp.Speak(say.Substring(spPos, i - spPos));
						spPos = i + "@phonetic(".Length;

						// TODO: try-catch
						// Find closing ')'
						string ph = say.Substring(spPos, say.Substring(spPos).IndexOf(')'));
						spPos += ph.Length + 1;

						// Speak with phonetic
						//Speaker spph = new Speaker(lang);
						//spph.UseSSML = true;
						//spph.Speak(spph.Phonetic(ph));
						sp.Speak(sp.Phonetic(ph));
					}

				}

			}
			sp.Speak(say.Substring(spPos));

		}
	}
}

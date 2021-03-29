using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace Oblig1_Modul3
{
    public class FamilyApp
    {
        public List<Person> _mannyPpl;
        public string WelcomeMessage = "Konge familien";
        public string CommandPrompt;

        public FamilyApp(params Person[] mannyPpl)
        {
            _mannyPpl = new List<Person>(mannyPpl);
        }

        public string HandleCommand(string command)
        {
            if (command == "hjelp")
            {
                return HjelpCommand();
            }

            if (command == "liste")
            {
                return ListeCommand();
            }

            if (command.Contains("vis "))
            {
                return VisCommand(command);
            }

            return "";
        }

        private string HjelpCommand()
        {
            return @"
hjelp => viser en hjelpetekst som forklarer alle kommandoene
liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)
";
        }

        private string ListeCommand()
        {
            string liste = string.Empty;
            for (int i = 0; i < _mannyPpl.Count; i++)
            {
                liste += _mannyPpl[i].GetDescription() + "\n";
            }

            return liste;
        }

        private string VisCommand(string input)
        {
            var ID = Int32.Parse(input.Substring(input.IndexOf(" ") + 1));
            string text = string.Empty;
            for (int i = 0; i < _mannyPpl.Count; i++)
            {
                if (_mannyPpl[i].Id == ID)
                {
                    text += GetPersonAndChildren(_mannyPpl[i], ID);
                }
            }

            return text;
        }

        private string GetPersonAndChildren(Person person, int ID)
        {
            List<string> children = new List<string>();
            string returnstring = "";
            string text = string.Empty;
            returnstring += person.GetDescription() + "\n";
            for (int i = 0; i < _mannyPpl.Count; i++)
            {
                if (_mannyPpl[i].Mother != null)
                {
                    if (_mannyPpl[i].Mother.Id == ID)
                    {
                        children.Add(_mannyPpl[i].FirstName + " (Id=" + _mannyPpl[i].Id + ") Født: " +
                                     _mannyPpl[i].BirthYear);
                    }
                }

                if (_mannyPpl[i].Father != null)
                {
                    if (_mannyPpl[i].Father.Id == ID)
                    {
                        children.Add(_mannyPpl[i].FirstName + " (Id=" + _mannyPpl[i].Id + ") Født: " +
                                     _mannyPpl[i].BirthYear);
                    }
                }
            }

            if (children.Count == 0)
            {
                return returnstring;
            }
            else
            {
                text += " " + " Barn:\n";
                for (int c = 0; c < children.Count; c++)
                {
                    if (c == children.Count - 1)
                    {
                        text += "    " + children[c] + "\n";
                    }
                    else
                    {
                        text += "    " + children[c] + "\n";
                    }
                }

                return returnstring + text;
            }
        }
    }
}
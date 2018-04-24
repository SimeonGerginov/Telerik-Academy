using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml;

using SuperheroesUniverse.Client.Exporters.Contracts;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Data.Repository.Contracts;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Client.Exporters
{
    public class SuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private readonly IEfRepository<Superhero> superheroesRepository;
        private readonly IEfRepository<Fraction> fractionsRepository;
        private readonly string filePath;

        public SuperheroesUniverseExporter(DbContext context, string filePath)
        {
            this.superheroesRepository = new EfRepository<Superhero>(context);
            this.fractionsRepository = new EfRepository<Fraction>(context);
            this.filePath = filePath;
        }

        public string ExportAllSuperheroes()
        {
            IEnumerable<Superhero> superheroes = this.superheroesRepository.GetAll();
            this.ExportHeroes(superheroes);

            return this.GetXmlString();
        }

        public string ExportFractionDetails(object fractionId)
        {
            Fraction fractionWithId = this.fractionsRepository
                .GetById((int)fractionId);
            this.ExportFractionDetails(fractionWithId);

            return this.GetXmlString();
        }

        public string ExportFractions()
        {
            IEnumerable<Fraction> fractions = this.fractionsRepository.GetAll();
            this.ExportFractions(fractions);

            return this.GetXmlString();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            Superhero superheroWithId = this.superheroesRepository
                .GetById((int)superheroId);
            this.ExportHeroDetails(superheroWithId);

            return this.GetXmlString();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            IEnumerable<Superhero> superheroesWithCity = this.superheroesRepository
                .GetAllFiltered(s => s.City.Name == cityName);
            this.ExportHeroes(superheroesWithCity);

            return this.GetXmlString();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            IEnumerable<Superhero> superheroesWithPower = this.superheroesRepository
                .GetAllFiltered(s => s.Powers.Any(p => p.Name == power));
            this.ExportHeroes(superheroesWithPower);

            return this.GetXmlString();
        }

        private string GetXmlString()
        {
            return File.ReadAllText(this.filePath);
        }

        private void ExportHeroes(IEnumerable<Superhero> superheroes)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("superheroes");

                foreach (var hero in superheroes)
                {
                    xmlWriter.WriteStartElement("superhero");

                    xmlWriter.WriteAttributeString("id", hero.Id.ToString());
                    xmlWriter.WriteElementString("name", hero.Name);
                    xmlWriter.WriteElementString("secretIdentity", hero.SecretIdentity);
                    xmlWriter.WriteElementString("alignment", hero.Alignment.ToString());

                    xmlWriter.WriteStartElement("powers");

                    foreach (var power in hero.Powers)
                    {
                        xmlWriter.WriteElementString("power", power.Name);
                    }

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteElementString("city", $"{hero.City.Name}, {hero.City.Country.Name}, {hero.City.Country.Planet.Name}");

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }

        private void ExportHeroDetails(Superhero hero)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("superhero");

                xmlWriter.WriteAttributeString("id", hero.Id.ToString());
                xmlWriter.WriteElementString("name", hero.Name);
                xmlWriter.WriteElementString("secretIdentity", hero.SecretIdentity);
                xmlWriter.WriteElementString("alignment", hero.Alignment.ToString());

                xmlWriter.WriteStartElement("powers");

                foreach (var power in hero.Powers)
                {
                    xmlWriter.WriteElementString("power", power.Name);
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("fractions");

                foreach (var fraction in hero.Fractions)
                {
                    xmlWriter.WriteElementString("fraction", fraction.Name);
                    xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteElementString("city", $"{hero.City.Name}, {hero.City.Country.Name}, {hero.City.Country.Planet.Name}");
                xmlWriter.WriteElementString("story", hero.Story);

                xmlWriter.WriteEndElement();
            }
        }

        private void ExportFractions(IEnumerable<Fraction> fractions)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("fractions");

                foreach (var fraction in fractions)
                {
                    xmlWriter.WriteStartElement("fraction");

                    xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                    xmlWriter.WriteAttributeString("membersCount", fraction.Members.Count.ToString());
                    xmlWriter.WriteElementString("name", fraction.Name);

                    xmlWriter.WriteStartElement("planets");

                    foreach (var planet in fraction.Planets)
                    {
                        xmlWriter.WriteElementString("planet", planet.Name);
                    }

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
        }

        private void ExportFractionDetails(Fraction fraction)
        {
            using (var xmlWriter = XmlWriter.Create(this.filePath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("fraction");

                xmlWriter.WriteAttributeString("id", fraction.Id.ToString());
                xmlWriter.WriteAttributeString("membersCount", fraction.Members.Count.ToString());
                xmlWriter.WriteElementString("name", fraction.Name);

                xmlWriter.WriteStartElement("planets");

                foreach (var planet in fraction.Planets)
                {
                    xmlWriter.WriteElementString("planet", planet.Name);
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("members");

                foreach (var member in fraction.Members)
                {
                    xmlWriter.WriteStartElement("member");
                    xmlWriter.WriteAttributeString("id", member.Id.ToString());
                    xmlWriter.WriteString(member.Name);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using SuperheroesUniverse.Client.Importers.Contracts;
using SuperheroesUniverse.Client.Importers.JsonModels;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Data.Repository.Contracts;
using SuperheroesUniverse.Models;
using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Client.Importers
{
    public class JsonSuperheroesImporter : ISuperheroesImporter
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IEfRepository<Superhero> superheroes;
        private readonly IEfRepository<City> cities;
        private readonly IEfRepository<Country> countries;
        private readonly IEfRepository<Power> powers;
        private readonly IEfRepository<Fraction> fractions;
        private readonly IEfRepository<Planet> planets;

        public JsonSuperheroesImporter(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Passed context is null!");
            }

            this.unitOfWork = new UnitOfWork(context);

            this.superheroes = new EfRepository<Superhero>(context);
            this.cities = new EfRepository<City>(context);
            this.countries = new EfRepository<Country>(context);
            this.powers = new EfRepository<Power>(context);
            this.fractions = new EfRepository<Fraction>(context);
            this.planets = new EfRepository<Planet>(context);
        }

        public void LoadSuperheroesData(string filePath)
        {
            string json = File.ReadAllText(filePath);

            var jsonSuperheroesCollection = JsonConvert.DeserializeObject<SuperheroesCollectionJsonModel>(json);
            this.AddSuperheroesToTheDatabase(jsonSuperheroesCollection.Superheroes);
        }

        private void AddSuperheroesToTheDatabase(IEnumerable<SuperheroJsonModel> superheroes)
        {
            foreach (var hero in superheroes)
            {
                IEnumerable<Superhero> currentHeroes = this.superheroes.GetAll();

                if (currentHeroes.Where(h => h.Name == hero.Name).FirstOrDefault() != null)
                {
                    continue;
                }

                Superhero superheroToAdd = new Superhero();

                // add name
                string heroName = hero.Name;
                superheroToAdd.Name = heroName;

                // add secret identity
                string heroIdentity = hero.SecretIdentity;
                superheroToAdd.SecretIdentity = heroIdentity;

                // add alignment
                string alignmentAsString = hero.Alignment;
                Alignment heroAlignment;

                Enum.TryParse<Alignment>(alignmentAsString, out heroAlignment);
                superheroToAdd.Alignment = heroAlignment;

                // add planet
                string heroPlanet = hero.City.Planet;
                IEnumerable<Planet> currentPlanets = this.planets.GetAll();

                Planet planetToAdd = currentPlanets.Where(p => p.Name == heroPlanet).FirstOrDefault();

                if (planetToAdd == null)
                {
                    planetToAdd = new Planet() { Name = heroPlanet };
                    this.planets.Add(planetToAdd);
                }

                // add country
                string heroCountry = hero.City.Country;
                IEnumerable<Country> currentCountries = this.countries.GetAll();

                Country countryToAdd = currentCountries.Where(c => c.Name == heroCountry).FirstOrDefault();

                if (countryToAdd == null)
                {
                    countryToAdd = new Country() { Name = heroCountry, PlanetId = planetToAdd.Id };
                    this.countries.Add(countryToAdd);
                }

                // add city
                string heroCity = hero.City.Name;
                IEnumerable<City> currentCities = this.cities.GetAll();

                City cityToAdd = currentCities.Where(c => c.Name == heroCity).FirstOrDefault();

                if (cityToAdd == null)
                {
                    cityToAdd = new City() { Name = heroCity, CountryId = countryToAdd.Id };
                }

                superheroToAdd.City = cityToAdd;

                // add story
                string heroStory = hero.Story;
                superheroToAdd.Story = heroStory;

                // add powers
                foreach (var power in hero.Powers)
                {
                    IEnumerable<Power> currentPowers = this.powers.GetAll();
                    Power powerToAdd = currentPowers.Where(p => p.Name == power).FirstOrDefault();

                    if (powerToAdd == null)
                    {
                        powerToAdd = new Power()
                        {
                            Name = power
                        };
                    }

                    superheroToAdd.Powers.Add(powerToAdd);
                }

                // add fractions
                foreach (var fraction in hero.Fractions)
                {
                    IEnumerable<Fraction> currentFractions = this.fractions.GetAll();
                    Fraction fractionToAdd = currentFractions.Where(f => f.Name == fraction).FirstOrDefault();

                    if (fractionToAdd == null)
                    {
                        fractionToAdd = new Fraction()
                        {
                            Name = fraction,
                            Alignment = heroAlignment
                        };

                        fractionToAdd.Planets.Add(planetToAdd);
                    }

                    superheroToAdd.Fractions.Add(fractionToAdd);
                }

                this.superheroes.Add(superheroToAdd);
                this.unitOfWork.SaveChanges();
            }
        }
    }
}

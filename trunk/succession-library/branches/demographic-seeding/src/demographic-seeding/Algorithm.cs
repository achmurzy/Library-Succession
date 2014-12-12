﻿using Landis.Core;
using Landis.SpatialModeling;
using Seed_Dispersal;

namespace Landis.Library.Succession.DemographicSeeding
{
    public class Algorithm
    {
        private Seed_Dispersal.Map seedingData;

        /// <summary>
        /// Initializes the demographic seeding algorithm
        /// </summary>
        /// <param name="successionTimestep">
        /// The length of the succession extension's timestep (units: years).
        /// </param>
        public Algorithm(int successionTimestep)
        {
            int numTimeSteps;  // the number of succession time steps to loop over
            int maxCohortAge;  // maximum age allowed for any species, in years

            numTimeSteps = (Model.Core.EndTime - Model.Core.StartTime) / successionTimestep;
            maxCohortAge = 0;
            foreach (ISpecies species in Model.Core.Species)
                if (species.Longevity > maxCohortAge)
                    maxCohortAge = species.Longevity;

            seedingData = new Seed_Dispersal.Map(
                Model.Core.Landscape.Columns,
                Model.Core.Landscape.Rows,
                Model.Core.Species.Count,
                numTimeSteps,
                successionTimestep,
                Model.Core.Ecoregions.Count,
                maxCohortAge);
            seedingData.pixel_size = Model.Core.CellLength;

            // Initialize some species parameters from the core.
            foreach (ISpecies species in Model.Core.Species)
            {
                seedingData.all_species[species.Index].shade_tolerance = species.ShadeTolerance;
                seedingData.all_species[species.Index].reproductive_age = species.Maturity;
            }
        }

        /// <summary>
        /// Seeding algorithm: determines if a species seeds a site.
        /// <param name="species"></param>
        /// <param name="site">Site that may be seeded.</param>
        /// <returns>true if the species seeds the site.</returns>
        public bool DoesSpeciesSeedSite(ISpecies   species,
                                        ActiveSite site)
        {
            throw new System.NotImplementedException();
        }
    }
}
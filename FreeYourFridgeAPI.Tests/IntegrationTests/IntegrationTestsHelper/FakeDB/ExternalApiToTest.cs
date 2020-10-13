using System.Collections.Generic;
using FreeYourFridge.API.Models;

namespace FreeYourFridgeAPI.Tests.IntegrationTestsHelper.FakeDB
{
    public class ExternalApiToTest
    {
        private List<AcceptRecipe> ExtRecipe = new List<AcceptRecipe>
        {
            new AcceptRecipe
            {
                readyInMinutes = 30,
                nutrition = new AcceptNutrition
                {
                    nutrients = new List<AcceptNutrient>
                    {
                        new AcceptNutrient
                        {
                            title = "Calories",
                            amount = 100,
                            unit = "cal",
                            percentOfDailyNeeds = 1
                        },
                        new AcceptNutrient
                        {
                            title = "Fat",
                            amount = 3,
                            unit = "g",
                            percentOfDailyNeeds = 3
                        },
                        new AcceptNutrient
                        {
                            title = "Carbohydrates",
                            amount = 20,
                            unit = "g",
                            percentOfDailyNeeds = 10
                        },
                        new AcceptNutrient
                        {
                            title = "Proteins",
                            amount = 5,
                            unit = "g",
                            percentOfDailyNeeds = 15
                        }

                    },

                    caloricBreakdown = new AcceptCaloricbreakdown
                    {
                        percentProtein = 30,
                        percentFat = 30,
                        percentCarbs = 30
                    },
                    properties = new List<AcceptProperties>
                    {
                        new AcceptProperties
                        {
                            title ="Glycemic Index",
                            amount = 30,
                            unit = ""
                        }
                    },
                    weightPerServing = new AcceptWeightperserving
                    {
                        amount = 120,
                        unit = "g"
                    }
                },
                analyzedInstructions = new List<AcceptAnalyzedinstruction>
                {
                    new AcceptAnalyzedinstruction
                    {
                        steps = new List<AcceptStep>
                        {
                            new AcceptStep
                            {
                                number = 1,
                                step = "the first step"
                            },
                            new AcceptStep
                            {
                                number = 2,
                                step = "the second step"
                            }
                        }
                    }
                }
            },
             new AcceptRecipe
            {
                readyInMinutes = 20,
                nutrition = new AcceptNutrition
                {
                    nutrients = new List<AcceptNutrient>
                    {
                        new AcceptNutrient
                        {
                            title = "Calories",
                            amount = 200,
                            unit = "cal",
                            percentOfDailyNeeds = 50
                        },
                        new AcceptNutrient
                        {
                            title = "Fat",
                            amount = 5,
                            unit = "g",
                            percentOfDailyNeeds = 50
                        },
                        new AcceptNutrient
                        {
                            title = "Carbohydrates",
                            amount = 30,
                            unit = "g",
                            percentOfDailyNeeds = 30
                        },
                        new AcceptNutrient
                        {
                            title = "Proteins",
                            amount = 40,
                            unit = "g",
                            percentOfDailyNeeds = 40
                        }

                    },

                    caloricBreakdown = new AcceptCaloricbreakdown
                    {
                        percentProtein = 50,
                        percentFat = 20,
                        percentCarbs = 40
                    },
                    properties = new List<AcceptProperties>
                    {
                        new AcceptProperties
                        {
                            title ="Different Index",
                            amount = 40,
                            unit = ""
                        }
                    },
                    weightPerServing = new AcceptWeightperserving
                    {
                        amount = 90,
                        unit = "g"
                    }
                },
                analyzedInstructions = new List<AcceptAnalyzedinstruction>
                {
                    new AcceptAnalyzedinstruction
                    {
                        steps = new List<AcceptStep>
                        {
                            new AcceptStep
                            {
                                number = 1,
                                step = "the first step of the second"
                            },
                            new AcceptStep
                            {
                                number = 2,
                                step = "the second step of the second"
                            }
                        }
                    }
                }
            },
        };
    }
}

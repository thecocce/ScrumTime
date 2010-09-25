﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScrumTime.Models;

namespace ScrumTime.ViewModels
{
    public class ScrumCollectionViewModel 
    {
        public List<Scrum> Scrums { get; set; }

        public ScrumCollectionViewModel()
        {
            Scrums = new List<Scrum>();
        }

        

        public static ScrumCollectionViewModel BuildByDateOfScrumDesc(int sprintId)
        {
            ScrumTimeEntities scrumTimeEntities = new ScrumTimeEntities();
            ScrumCollectionViewModel scrumCollectionViewModel = new ScrumCollectionViewModel();
            if (sprintId > 0)
            {
                Sprint sprint = scrumTimeEntities.Sprints.First<Sprint>(s => s.SprintId == sprintId);
                var results = from s in sprint.Scrums
                              orderby s.DateOfScrum descending
                              select s;
                List<Scrum> scrums = results.ToList<Scrum>();
                scrumCollectionViewModel.Scrums = scrums;
            }
            return scrumCollectionViewModel;
        }
    }
}
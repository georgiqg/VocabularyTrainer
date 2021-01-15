using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VocabularyTrainer.Models
{
    public class Gender
    {
        public int GenderId { get; set; }

        [StringLength(50)]
        public string GenderName { get; set; }

        [StringLength(50)]
        public string GenderColor { get; set; }

        private ICollection<string> colors;

        public Gender()
        {
            colors = new List<string>
            {
                "aqua",
                "aquamarine",
                "blue",
                "chartreuse",
                "deepskyblue",
                "dodgerblue",
                "forestgreen",
                "gold",
                "greenyellow",
                "lime",
                "orange",
                "orangered",
                "red"
            };
        }
    }
}
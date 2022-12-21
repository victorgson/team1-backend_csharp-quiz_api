using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Quiz.Domain.Entities
{

 
	public class Question
	{

        public Guid Id { get; set; }
        public string Language { get; set; }
		public string QuestionString { get; set; }
        public string Category { get; set; }


        public Question()
        {
            Id = Guid.NewGuid();
        }

    }
}


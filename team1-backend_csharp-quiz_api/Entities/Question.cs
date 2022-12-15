using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace team1_backend_csharp_quiz_api.Entities
{

 
	public class Question
	{

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Language { get; set; }
		public string QuestionString { get; set; }
        public string Category { get; set; }

    }
}


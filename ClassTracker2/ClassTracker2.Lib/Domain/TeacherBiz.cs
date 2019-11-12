using Common;
using dto = ClassTracker2.Dto.TeacherDto;
using thisResult = Common.Result<System.Int32, ClassTracker2.Dto.TeacherDto>;
using System;
using System.Security;
using ClassTracker2.Repo;
using ClassTracker2.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ClassTracker2.Lib
{
    public class TeacherBiz : IDomain<int, dto>
    {
        private readonly TeacherRepo repo = new TeacherRepo();

        public thisResult StartGetById(int key)
            => new Result<int, dto>(key);

        public IResult GetById(int key) 
            =>
            StartGetById(key)
                .Validate(Helpers.ValidateKey)
                .BindOutput<int, TeacherDto>(repo.GetById);

        public TeacherDto GetById2(int key)
        {
            var validationIssues = new List<string>();
            var message = Helpers.ValidateKey<int>(key);
            if (!string.IsNullOrEmpty(message))
            {
                validationIssues.Add(message);
            }
            if (validationIssues.Count() == 0)
            {
                try
                {
                    return repo.GetById(key);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return default; // How to return validation issues?
                            // Calling code has to check for valid dto, no indication that this is needed
        }


    }
}

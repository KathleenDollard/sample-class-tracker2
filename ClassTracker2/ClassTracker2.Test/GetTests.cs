using ClassTracker2.Dto;
using ClassTracker2.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Common;
using System;

namespace ClassTracker2.Test
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void ZeroTeacherIdFailsValidation()
        {
            // Setup - as from controller
            var key = 0; // in parameter 
            IResult result = CrudHandler.Get<TeacherDto>(key);

            Assert.AreEqual(1, result.ValidationIssues.Count());
            Assert.AreEqual("Key must be greater than zero", result.ValidationIssues.First());

        }

        [TestMethod]
        public void CanGetTeacherById()
        {
            // Setup - as from controller
            var key = 6; // in parameter 
            IResult result = CrudHandler.Get<TeacherDto>(key);

            Assert.IsTrue(result.ValidationIssues.Count() == 0);
            Assert.IsTrue(result.Exceptions.Count() == 0);
            TeacherDto typedResult = result switch
            {
                Result<int, TeacherDto> x => x.Output,
                _ => default
            };
            Assert.AreEqual("Apple", typedResult.FirstName);
        }

        [TestMethod]
        public void ZeroSemesterIdFailsValidation()
        {
            // Setup - as from controller
            var key = 0; // in parameter 
            IResult result = CrudHandler.Get<SemesterDto>(key);

            Assert.AreEqual(1, result.ValidationIssues.Count());
            Assert.AreEqual("Key must be greater than zero", result.ValidationIssues.First());

        }

        [TestMethod]
        public void CanGetSemesterById()
        {
            // Setup - as from controller
            var key = 26; // in parameter 
            IResult result = CrudHandler.Get<SemesterDto>(key);

            Assert.IsTrue(result.ValidationIssues.Count() == 0);
            Assert.IsTrue(result.Exceptions.Count() == 0);
            SemesterDto typedResult = result switch
            {
                Result<int, SemesterDto> x => x.Output,
                _ => default
            };
            Assert.AreEqual(DateTime.Parse("2019-03-01"), typedResult.StartDate);
        }
    }
}

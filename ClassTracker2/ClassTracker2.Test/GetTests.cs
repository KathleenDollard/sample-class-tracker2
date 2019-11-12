using ClassTracker2.Dto;
using ClassTracker2.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Common;

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

            Assert.AreEqual(result.ValidationIssues.Count(), 1);
            Assert.AreEqual(result.ValidationIssues.First(), "Key must be greater than zero");

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
            Assert.AreEqual(typedResult.FirstName, "Apple");
    }
}
}

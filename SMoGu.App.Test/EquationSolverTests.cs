using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace SMoGu.App.Test
{
    [TestClass]
    public class EquationSolverTests
    {
        [TestMethod]
        public void CheckSolutionExists()
        {
            var solvable = new double[3][]
            {
                new [] {2d, 3d, 4d, 33d},
                new [] {7d, 5d, 0d, 24d},
                new [] {4d, 0d, 11d, 39d}
            };
            MethodInfo modifier = typeof(EquationSolver).GetMethod("ModifyMatrix", BindingFlags.Static | BindingFlags.NonPublic);
            modifier.Invoke(null, new[] { solvable });
            Assert.IsTrue(EquationSolver.SolutionExists(solvable, 3));
        }

        [TestMethod]
        public void CheckNoSolutionExists()
        {
            var unsolvable = new double[3][]
            {
                new [] {4d, -3d, 2d, -1d, 8d},
                new [] {3d, -2d, 1d, -3d, 7d},
                new [] {5d, -3d, 1d, -8d, 1d}
            };
            MethodInfo modifier = typeof(EquationSolver).GetMethod("ModifyMatrix", BindingFlags.Static | BindingFlags.NonPublic);
            modifier.Invoke(null, new[] { unsolvable });
            Assert.IsFalse(EquationSolver.SolutionExists(unsolvable, 4));
        }

        [TestMethod]
        public void SolverFindsSolution_WhenOneSolution()
        {
            var matrix = new double[4][]
            {
                new [] {2d, 5d, 4d, 1d},
                new [] {1d, 3d, 2d, 1d},
                new [] {2d, 10d, 9d, 7d},
                new [] {3d, 8d, 9d, 2d}
            };
            var freeColumn = new[] { 20d, 11d, 40d, 37d };
            var actual = EquationSolver.RunGaussSolver(matrix, freeColumn);
            var expected = new double[] { 1d, 2d, 2d, 0d };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SolverFindsSolution_WhenInfSolutions()
        {
            var infSolutionsMatrix = new double[4][]
            {
                new [] {2d, 3d, -1d, 1d},
                new [] {8d, 12d, -9d, 8d},
                new [] {4d, 6d, 3d, -2d},
                new [] {2d, 3d, 9d, -7d}
            };
            var freeColumn = new[] { 1d, 3d, 3d, 3d };
            var actual = EquationSolver.RunGaussSolver(infSolutionsMatrix, freeColumn);
            var expected = new double[] { 0.6d, 0d, 0.2d, 0d };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SolverSubstitutes_WhenNoSolution()
        {
            var matrix = new double[3][]
            {
                new [] {5d, -9d, -4d},
                new [] {1d, -7d, -5d},
                new [] {4d, -2d, 1d}
            };
            var freeColumn = new[] { 6d, 1d, 2d };
            var actual = EquationSolver.RunGaussSolver(matrix, freeColumn);
            var expected = new double[] { 0.5d, 0.25d, 0.125d };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
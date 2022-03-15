using System;
using Smells.CodeSmellExamples;

namespace Smells.CodeSmellDispatch
{
    public class Dispatcher
    {
        private string[] Choices = {
            "dead-local-store",
            "duplicate-code",
            "feature-envy",
            "god-class",
            "long-method",
            "self-assignment",
            "short-circuit",
            "type-checking"
        };

        public void DispatchCodeSmell(string smell, string variant)
        {
            switch (smell)
            {
                case "dead-local-store":
                    RunDeadLocalStore(variant);
                    break;
                case "duplicate-code":
                    RunDuplicateCode(variant);
                    break;
                case "feature-envy":
                    RunFeatureEnvy(variant);
                    break;
                case "god-class":
                    RunGodClass(variant);
                    break;
                case "long-method":
                    RunLongMethod(variant);
                    break;
                case "repeated-conditionals":
                    RunRepeatedConditionals(variant);
                    break;
                case "self-assignment":
                    RunSelfAssignment(variant);
                    break;
                case "short-circuit":
                    RunShortCircuit(variant);
                    break;
                case "type-checking":
                    RunTypeChecking(variant);
                    break;
                default:
                    Console.WriteLine("Error: argument \"" + smell + "\" not recognized, please try again.");
                    Console.WriteLine("Available arguments are:");
                    Console.WriteLine("{ " + String.Join(", ", Choices) + " }");
                    break;
            }
        }

        private void RunDeadLocalStore(string variant)
        {
            int iterations = 200000000; // 200M

            DeadLocalStoreBase LocalStore;
            if (variant == "bad") LocalStore = new DeadLocalStoreBad();
            else LocalStore = new DeadLocalStoreGood();
            
            Console.WriteLine("Running code smell Dead Local Store, variant " + variant);
            for (int i = 0; i < iterations; i++) LocalStore.DeadLocalStore(100);
            Console.WriteLine("Done");
        }

        private void RunDuplicateCode(string variant)
        {
            int iterations = 100000000; // 100M

            DuplicateCodeBase Duplicate;
            if (variant == "bad") Duplicate = new DuplicateCodeBad();
            else Duplicate = new DuplicateCodeGood();

            Console.WriteLine("Running code smell Duplicate Code, variant " + variant);
            for (int i = 0; i < iterations; i++) Duplicate.SumElements();
            Console.WriteLine("Done");
        }

        private void RunFeatureEnvy(string variant)
        {
            int iterations = 50000000; // 50M

            FeatureEnvyBase Envy;
            if (variant == "bad")
            {
                ContactInfo Info = new ContactInfo();
                Envy = new FeatureEnvyBad(Info);
            }
            else Envy = new FeatureEnvyGood();

            Console.WriteLine("Running code smell Feature Envy, variant " + variant);
            for (int i = 0; i < iterations; i++) Envy.GetFullAddress();
            Console.WriteLine("Done");
        }

        private void RunGodClass(string variant)
        {
            Console.WriteLine("Not implemented");
        }

        private void RunLongMethod(string variant)
        {
            int iterations = 5000000; // 5M

            LongMethodBase LongMethod;
            if (variant == "bad") LongMethod = new LongMethodBad();
            else LongMethod = new LongMethodGood();

            Console.WriteLine("Running code smell Long Method, variant " + variant);
            for (int i = 0; i < iterations; i++) LongMethod.Compute();
            Console.WriteLine("Done");
        }

        private void RunParameterByValue(string variant)
        {
            Console.WriteLine("Not implemented");
        }

        private void RunRepeatedConditionals(string variant)
        {
            Console.WriteLine("Not implemented");
        }

        private void RunSelfAssignment(string variant)
        {
            int iterations = 50000000; // 50M

            SelfAssignmentBase SelfAssignment;
            if (variant == "bad") SelfAssignment = new SelfAssignmentBad();
            else SelfAssignment = new SelfAssignmentGood();

            Console.WriteLine("Running code smell Self Assignment, variant " + variant);
            for (int i = 0; i < iterations; i++) SelfAssignment.SelfAssignment();
            Console.WriteLine("Done");
        }

        private void RunShortCircuit(string variant)
        {
            int iterations = 200000000; // 200M

            ShortCircuitBase ShortCircuit;
            if (variant == "bad") ShortCircuit = new ShortCircuitBad();
            else ShortCircuit = new ShortCircuitGood();

            Console.WriteLine("Running code smell Non-Short Circuit, variant " + variant);
            for (int i = 0; i < iterations; i++) ShortCircuit.ShortCircuit();
            Console.WriteLine("Done");
        }

        private void RunTypeChecking(string variant)
        {
            int iterations = 500000000; // 500M

            TypeCheckingBase TypeChecking;
            if (variant == "bad") TypeChecking = new TypeCheckingBad(false, true);
            else TypeChecking = new TypeCheckingGood(new Salesman());

            Console.WriteLine("Running code smell Type Checking, variant " + variant);
            for (int i = 0; i < iterations; i++) TypeChecking.getType();
            Console.WriteLine("Done");
        }
    }
}
namespace CSharp.Experiments.FromDocumentation.CovarianceAndContravariance;

public class Sample
{
    public void PlayAround()
    {
        // In C#, covariance and contravariance enable implicit reference conversion for
        // --> array types,
        // --> delegate types,
        // --> and generic type arguments.
        // Covariance preserves assignment compatibility and contravariance reverses it.

        // Case 1:
        // Assignment compatibility.
        var myString = "This is a string.";
        // An object of a more derived type (String) is assigned to an object of a less derived type,
        // or, in other words, is assogned to an object of a more generic type.
        var myObject = myString;

        /////////////////////////////////////////////////////////////////////////////////////////////

        // Case 2:
        // Covariance.
        IEnumerable<string> myListOfStrings = new List<string>();
        IEnumerable<object> myListOfObjects = myListOfStrings;

        /////////////////////////////////////////////////////////////////////////////////////////////

        // Case 3:
        // Contravariance.
        static void SetObject(object o) { }
        Action<object> setObjectAction = SetObject;
        // An object that is instantiated with a less derived type argument
        // is assigned to an object instantiated with a more derived type argument.
        // Assignment compatibility is reversed.
        Action<string> setStringAction = setObjectAction;

        // Test 1:
        object testObject = new Object();
        setObjectAction(testObject);
        // A compilation error.
        // setStringAction(testObject);

        // Test 2:
        string testString = "This is a test string";
        setObjectAction(testString);
        setStringAction(testString);

        // Test 3:
        static void SetString(string s) { }
        setStringAction = SetString;
        // A compilation error.
        // setStringAction(testObject);
        setStringAction(testString);
    }
}

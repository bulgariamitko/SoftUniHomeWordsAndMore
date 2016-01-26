function studentsCoursesGradesVisits(input) {
    var output = {};

    for (var i = 0; i < input.length; i++) {
        var arrayOfThing = input[i].split("|");
        var name = arrayOfThing[0].trim();
        var subject = arrayOfThing[1].trim();
        var score = Number(arrayOfThing[2].trim());
        var visits = Number(arrayOfThing[3].trim());

        // console.log("|" + name + "|" + subject + "|" + score + "|" + visits + "|");
        if (!output[subject]) {
            output[subject] = {"all":0,"allGrades":0,"allVisits":0,"avgGrade":0,"avgVisits":0,"students":[]};
        }
        
        output[subject]["all"]++;
        output[subject]["allGrades"] += score;
        output[subject]["allVisits"] += visits;
        output[subject]["students"].push(name);

        // REMOVE DUPLICATES FROM ARRAY!
        output[subject]["students"] = output[subject]["students"].filter(function(item, pos, self) {
            return self.indexOf(item) == pos;
        });
        
    }


    for(var outing in output) {
        var avgGrades = output[outing]["allGrades"] / output[outing]["all"];
        output[outing]["avgGrade"] = Math.round(avgGrades*100)/100;
        // console.log(output[outing]["avgGrade"]);

        var avgVisit = output[outing]["allVisits"] / output[outing]["all"];
        output[outing]["avgVisits"] = Math.round(avgVisit*100)/100;
        // console.log(output[outing]["avgVisits"]);

        delete output[outing]["all"];
        delete output[outing]["allGrades"];
        delete output[outing]["allVisits"];
    }

    for(var ii in output) {
        output[ii]["students"].sort();
    }

    output = sortByKeys(output);
    console.log(JSON.stringify(output));

    function sortByKeys(inputMap) {
        var resultMap = {};
        var keyArr = Object.keys(inputMap);
        keyArr.sort();
        for (var key in keyArr) {
            resultMap[keyArr[key]] = inputMap[keyArr[key]];
        }
        return resultMap;
    }
}
// studentsCoursesGradesVisits(["Peter Nikolov | PHP  | 5.50 | 8", "Maria Ivanova | Java | 5.83 | 7", "Ivan Petrov   | PHP  | 3.00 | 2", "Ivan Petrov   | C#   | 3.00 | 2", "Peter Nikolov | C#   | 5.50 | 8", "Maria Ivanova | C#   | 5.83 | 7", "Ivan Petrov   | C#   | 4.12 | 5", "Ivan Petrov   | PHP  | 3.10 | 2", "Peter Nikolov | Java | 6.00 | 9"]);
studentsCoursesGradesVisits(["Milen Georgiev|PHP|2.02|2", "  Ivan Petrov | C# Basics | 3.20 | 22", "Peter Nikolov | C# | 5.522 | 18", "Maria Kirova | C# Basics | 5.40 | 4.5", "Stanislav Peev | C# | 4.012 | 15", "   Ivan Petrov |    PHP Basics     |     5.120 |6", "Ivan Goranov | SQL | 5.926 | 12", "Todor Kirov | Databases | 5.50 |0.0000", "Maria Ivanova | Java | 5.83 | 37", "Milena Ivanova |    C# |   1.823 | 4.5", "     Stanislav Peev   |    C#|   4.122    |    15   ", "Kiril Petrov |PHP| 5.10 | 6", "Ivan Petrov|SQL|5.926|3", "      Peter Nikolov   |    Java  |   5.9996    |    9   ", "Stefan Nikolov | Java | 4.00 | 9.5", "Ivan Goranov | SQL | 5.926 | 12.5", "Todor Kirov | Databases | 5.150 |0.0000", "Kiril Ivanov | Java | 5.083 | 327", "Diana Ivanova |    C# |   1.823 | 4", "     Stanislav Peev   |    C#|   4.122    |    15   ", "Kiril Petrov |PHP| 5.10 | 6"]);

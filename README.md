# AutomationTest_Code Tests

---**Task 1 notes:**---

GameManager.cs class issues:
1) Bug: When roundCount is 0 or even negative number (e.g. -1), the alghorithm goes 1 round but should not
2) Potential Bug: negative number for bet should not be applicable

Pull Request:
https://github.com/tsekhmeistruk/AutomationTest_Code/pull/1

---**Task 2 notes:**---

Current implementation does not follow one of the task's requirements: _"The module should get as an input playerID as an integer"_
Following this rule may require a 'big' refactoring of the whole GameManager class because multi player is not supported yet.

I hope it is not a big deal.

Second Task Pull Request:
https://github.com/tsekhmeistruk/AutomationTest_Code/pull/2

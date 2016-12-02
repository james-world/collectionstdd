# TDD Exercise: Most Recently Used List

## Introduction

This is a practice exercise to develop your TDD skills. The source code is an example solution you can consult after attempting the exercise.

Instructions

Read the specification below, and develop implementation.
1.	If you do not have it already, install the `NUnit 3 Test Adapater` extension from the *Tools>Extensions and Updates* menu in Visual Studio.
2.	Create a class library project called `MruListExercise`.
3.	Install `NUnit 3.x` from the Package Manager Console (if not visible it is accessible from *View>Other Windows*) by entering `install-package nunit`
4.	Create a class `MruListTests` to hold your tests. Add the `NUnit.Framework` namespace to your using declarations and create an empty test decorated with the [Test] attribute. Check that you can run your test from the *Test>Run>All Tests* menu. Pin the *Test Explorer* window that should show the passing test. Note the `Ctrl+R, A` default extension to run all tests.
5.	Remember the laws of TDD:
* **First Law**
You may not write production code until you have written a failing unit test. (Run it to check it fails).
* **Second Law**
You may not write more of a unit test than is sufficient to fail, and not compiling is failing.
* **Third Law**
You may not write more production code than is sufficient to pass the currently failing test. (Run tests to check they all pass).

6.	And the guidelines:
    1.	Keep your code and tests clean - Red, Green, Refactor
    2.	One logical assert per test
    3.	Start with the degenerate test cases.
    4.	As the test gets more specific, the code gets more generic.

## Specification

Develop a most-recently-used-list **class** to hold strings uniquely in Last-In-First-Out order such that:
* A recently-used-list is initially empty.
* The most recently added item is first, the least recently added item is last.
* Items can be looked up by index, which counts from zero.
* Items in the list are unique, so duplicate insertions are moved rather than added.
* Optional extras
* Null insertions (empty strings) are not allowed.
* A bounded capacity can be specified, so there is an upper limit to the number of items contained, with the least recently added items dropped on overflow.

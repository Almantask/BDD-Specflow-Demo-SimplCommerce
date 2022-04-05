@ignore
Feature: UserRegistration

A short summary of the feature

@tag1
Scenario: a failed registration attempt due to server validation
    Given a client has an invalid register user request
    When the client sends a register user reuqest
    Then a registration entry should be created
    But the user should not be registered

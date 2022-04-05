@ignore
Feature: GetUser

A short summary of the feature

@tag1
Scenario: Get existing user
    Given a client has a get user request
    And user id is 1
    When they send the get user request
    Then they should get a get user response
    And the response should have body
    ```
    {
        "User": {
            "Id": 1,
            ...
        },
        ...
    }
    ```
    And status code is 200

Scenario: Get existing user2
    Given a client has a get user request
    And user id is 1
    When they send the get user request
    Then they should get a get user response
    * with body
    ```
    {
        "User": {
            "Id": 1,
            ...
        },
        ...
    }
    ```
    * with status code 200


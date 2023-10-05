Feature: GetUser

Get user

Scenario: Get existing user
    Given I have "POST" "/user/<ExistingUserId>" request
    When I send the request
    Then status code should be 200 
    And the response body should be
    ```
    {
        "User": {
            "Id": <ExistingUserId>,
	},
        ...
    }
    ```

    Examples:
    | ExistingUserId | Description                          |
    | 1              | Disabled user can still be retrieved |
    | 2              | Enabled user                         |

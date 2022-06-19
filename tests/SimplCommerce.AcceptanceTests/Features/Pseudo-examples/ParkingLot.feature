@ignore
Feature: Economy Parking feature
  The parking lot calculator can calculate costs for Economy parking.

Scenario: Calculate Economy Parking Cost
    Given parking lot is Economy
    And parking duration is <duration>
    When the cost estimate is calculated
    Then the parking cost should be <cost>

Examples:
    | description                       | duration           | cost    |
    | didn't park                       | 0 minute           | 0.00€   |
    | 2€ is 1h cap                      | 30 minutes         | 2.00€   |
    | at 1h cap                         | 1 hour             | 2.00€   |
    | 1h before 1d cap                  | 4 hours            | 8.00€   |
    | 9€ is 1d cap                      | 5 hours            | 9.00€   |
    | at 1d cap reset                   | 24 hours           | 9.00€   |
    | 1h after 1d cap reset             | 1 day, 1 hour      | 11.00€  |
    | 54€ is 1 week cap                 | 6 days             | 54.00€  |
    | at 1 week cap reset               | 7 days             | 54.00€  |
    | multiple days and weeks and hours | 2 weeks, 2 days 1h | 128.00€ |
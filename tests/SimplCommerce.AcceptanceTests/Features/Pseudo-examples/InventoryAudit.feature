Feature: Inventory audit

Scenario: Auditor alerts one missing item
Given 1 missing item from inventory
When auditor performs audit
Then they alert the supplier

Scenario: Auditor does nothing on extra items
Given 1 extra item from inventory
When auditor performs audit
Then they do not alert the supplier

Scenario: Report damaged goods
Given inventory report contains 1 damaged Vase
And inventory report contains 2 good Crates of Vine
And inventory report contains 2 Samsung TVs
When auditor performs audit
Then Vase is reported as damaged
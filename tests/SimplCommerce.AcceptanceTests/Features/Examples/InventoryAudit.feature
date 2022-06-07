Feature: Inventory audit

Scenario: Auditor alerts one missing item
Given 1 missing item from inventory
When auditor performs audit
Then they alert the supplier

Scenario: Auditor does nothing on extra items
Given 1 extra item from inventory
When auditor performs audit
Then they do not alert the supplier
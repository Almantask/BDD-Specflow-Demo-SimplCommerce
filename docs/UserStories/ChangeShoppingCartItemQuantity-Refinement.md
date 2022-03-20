# Change shopping cart item quantity refinement

## The purpose of this example

[BDD (Behavior Driven Development)](https://cucumber.io/docs/bdd/#what-is-bdd) is a great way of working in an [Agile](https://agilemanifesto.org/) world. Many people think they are doing BDD as soon as they start using test automation frameworks such as Gherkin or Cucumber, but that is far from true. There are 3 pillars of BDD:

- Discovery - exploring requirements through examples
- Formulation - creating scenarios (as documentation) out of examples. Feature files
- Automation - verifying scenarios through automated tests (writing glue code)

## Whom should be intested in this?

The whole Agile Team should be interested, because:

- **Product owner** will spend significantly less time answering questions during the sprint (because there simply won't be that many questions due to better refined stories)
- **Tester** will not need to write so many test cases themselves, because they will be automated
- **Developer** will waste less time implementing innacurate (or worse - wrong) requirements
- **Developer and Tester** (and this is quite a key thing) will communicate with each other when defining scenarios.

One common myth - testers should write scenarios. If you want to make 100% use of BDD - use scenario writing as an opportunity for a tester and developer to collaborate together. When scenarios are written, give a PO a shout and ask for a review.

## The evolution

The following will illustrate a [refinement](https://www.digite.com/agile/backlog-refinement/) of a single [user story](https://www.atlassian.com/agile/project-management/user-stories) through stages and alternatives ways of how it could have gone:
[1](#1---plain-story)
[2](#2---introducing-roles-and-acceptence-criteria), 
[3](#3---no-solutionizing-and-better-roles) 
[4](#4---exploring-the-story-through-examples) 
[5](#5---more-examples-and-grouped-to-business-rules)
[6](#6---open-questions-or-why-its-okay-to-not-know-everything)

### [1 - Plain story](ChangeShoppingCartItemQuantityv1.md)

Plain user story, with requirements written by [product owner](https://www.scaledagileframework.com/product-owner/). The product owner noted what he would like done without putting any detail. This is quite typical and a totally fine way of doing things. However, this story still needs to be refined.

### [2 - Introducing roles and acceptence criteria](ChangeShoppingCartItemQuantityv2.md)

During the refinement session the team quickly puts somes notes together **how** the story could be done. They decide that the easiest way to do it is by adding 2 buttons: "+" and "-" for incrementing and decrementing item quantity. A text box element can be used to edit the quantity directly. The team thinks that is all, that it will take no more than half a day and are happy with an estimate of 2.

The story is refined.

The problem with this approach is that the team didn't look at the story from a business perspective. Therefore, they completely missed where the complexity of the story comes from.

### [3 - Don't solutionize](ChangeShoppingCartItemQuantityv3.md)

Instead of saying how to do it, it's better define **what** you want to do. Maybe instead of the buttons there will be a slider for quantity? Leave that up to the ones who implement the story to design. A design can be a separate story, because it is a prerequisite and can change altogether some aspects (for example whether we need the text box altogether).

This is slightly better, because work is a bit more sliced, but the story is still lacking.

### [4 - Exploring the story through Gherkin examples](ChangeShoppingCartItemQuantityv4.md)

Someone from the testers loves automation and to help themselves out and do less work - they adviced the team to rewrite acceptence criteria using examples written in Gherkin languages. "If we don't know preconditions, input and output" - he said - "then we don't really understand the story" - he finished.

Gherkin does help by framing us into thinking from a practical point of view. It's good to have examples. But acceptance crtieria and examples are 2 different things. One is a set of rules that we need to follow. The other is how those rules are applied. Also, Gherkin is code (even though human readable) and it takes time to write clear and consistent code (it also needs to be detailed). Lastly, figuring out examples of invalid input in this story are more a job of a tester than of the whole team. Don't get confused, different examples should be used, but examples to cover different business cases rather than edge cases.

### [5 - More and simplified examples and grouped to business rules](ChangeShoppingCartItemQuantityv5.md)

Not writing examples in Gherkin doesn't mean you shouldn't write examples at all. **The whole point of BDD - is discovering a user story through examples**. Then **use** those **examples to formulate the scenarios**. And finally **use scenarios to create living documentation verified through automate tests**. Simple examples speed things up and allows us to focus on what matters. `=>` marks outcome. Everything else is either precondition, input or action - we don't care which is which - our focus is to just define a clear example. A good example should focus on a single rule. A single rule can have more than one example.

However, one question remains - what should be done if the input is invalid?

### [6 - Open questions or why it's okay to not know everything](ChangeShoppingCartItemQuantityv6.md)

As mentioned in the v3 refinement, don't solutionize. It's okay to not know things, as long as you are aware of what you don't know. However, don't just leave a question mark on a part that you should cover - write the questions down.

## Summary

In BDD, a user story should be defined using:

- A short description using a persona.
- Acceptence criteria (rules)
- Rules should be illustrated through examples (written in any form, as long as it is convenient)
- Do all you can to figure out all the business cases, but don't guess what you don't know - leave open questions where necessary
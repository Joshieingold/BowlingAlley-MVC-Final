# Bowling Tournament: Team Roles, Workflow & GitHub Guide

Josh, Sarah and Erika · SSW Fall 2026 · Prepared Nov 23, 2026

## 1. The plan in one minute

- Josh builds the foundation first (about 2 days): project scaffold, data layer, routes, login. Everything after that is split into vertical slices: **one use case = one issue = one branch = one pull request (PR)**.
- While the foundation is being built, Sarah and Erika work on tasks that do not depend on it (layout and UI, test data, seed script), so nobody waits.
- Every PR is reviewed by Josh. Josh's own PRs are approved by Sarah. Reviews happen within 24 hours, and the author merges their own PR once it is approved.
- Everyone always has at least two independent tasks queued, so a pending review or a blocker never stops work.

**Key dates:** status reports are due Fri Nov 27, Fri Dec 4 and Fri Dec 11 (the Nov 20 report has already passed). Josh writes each report from the project board, Sarah and Erika review it and add anything missing, and Josh submits the final version. Code must be complete and frozen by Dec 13. The plan below finishes all coding by Dec 10, which leaves Dec 11 to 13 as buffer.

## 2. Roles

### Josh: Tech Lead and Project Manager

- **Foundation:** solution scaffold (ASP.NET 10 MVC, EF Core, SQLite), models, DbContext, ViewModels, schema SQL script, Program.cs, routing and navigation skeleton.
- **Authentication:** MVC-04 Login, MVC-05 Logout, password hashing, protecting every AdminController action.
- **Team editing:** MVC-07 Edit Team (including the paid-team rules for fee and date) and the shared validation rules on the ViewModels.
- **Project management:** GitHub setup, issue board, review of every PR, schema changes, status reports, final merge readiness.

### Sarah: UI Lead and Backend (Public Site, Team Creation, Players)

- **UI:** \_Layout, navigation styling, CSS, shared partials, flash messages, consistent look, final UX polish.
- **Public site backend:** MVC-01 Register Team (validation, duplicate team names, exactly four players), MVC-02 View Paid Teams, MVC-03 View Team Details.
- **Team creation and roster backend:** MVC-06 Create Team (the admin version of the registration form) and MVC-09 Manage Players (add and remove players, enforce the four-player rule).

### Erika: Admin Operations, Reporting, Data and QA

- **Admin operations:** MVC-08 Delete Team (confirmation page, removes the team's players), MVC-10 Mark Team as Paid (records the $200 fee and payment date), MVC-11 Filter Teams by division and paid status.
- **Reporting:** MVC-12 Registration Summary and MVC-13 Division Summary (bonus, LINQ grouping).
- **Data:** her share of the shared bowling teams and players spreadsheet, the seed SQL script, and the test that the database can be rebuilt from scratch.
- **Testing and wrap-up:** leads the robustness pass across every use case (bad IDs, URL manipulation, duplicate names, bypass attempts), plus the Home page and the final README.

This split keeps each person in their own controller files and view folders, which is what removes most merge conflicts and waiting.

## 3. Ownership map

Owners edit these freely. Anyone else who needs a change makes a small PR and tags the owner.

| Area                          | Files                                                                                                                                          | Owner |
| ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- | ----- |
| Foundation                    | Program.cs, Models/, Data/BowlingContext.cs, ViewModels/, database/01\_schema.sql                                                              | Josh  |
| Auth                          | AuthController, Views/Auth                                                                                                                     | Josh  |
| Team editing                  | AdminController.Teams.cs (EditTeam), Views/Admin/EditTeam                                                                                      | Josh  |
| Public site                   | TeamController, Views/Team                                                                                                                     | Sarah |
| Roster (create team, players) | AdminController.Roster.cs (CreateTeam, ManagePlayers, AddPlayer, RemovePlayer), Views/Admin/CreateTeam, ManagePlayers, AddPlayer               | Sarah |
| Look and feel                 | Views/Shared/\*, wwwroot/css                                                                                                                   | Sarah |
| Admin operations and reports  | AdminController.Operations.cs (Index, DeleteTeam, MarkPaid, Summary, DivisionSummary), Views/Admin/Index, DeleteTeam, Summary, DivisionSummary | Erika |
| Home, data, docs              | HomeController, Views/Home, README.md, database/02\_seed\_data.sql                                                                             | Erika |

**AdminController is a partial class split across three files** (Teams, Roster, Operations). It is still one controller, as the spec suggests, but nobody edits the same file at the same time. Josh creates the three files with stubs in the foundation phase.

## 4. Work breakdown

Josh creates these as GitHub issues in this order so issue numbers match the table. Each person works their own rows top to bottom.

| #   | Task                                                                                                                                                                                                            | Owner | Needs   | Size | Target     |
| --- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----- | ------- | ---- | ---------- |
| 1   | Scaffold repo: ASP.NET 10 MVC project, EF Core and SQLite packages, .gitignore, folders                                                                                                                         | Josh  | none    | S    | Mon Nov 23 |
| 2   | Data layer: models, BowlingContext, ViewModels, database/01\_schema.sql with Division lookup                                                                                                                    | Josh  | 1       | M    | Tue Nov 24 |
| 3   | Skeleton: stub actions for every use case, AdminController partial files (Teams, Roster, Operations), routes, nav links, cookie auth with MVC-04/05 Login and Logout, \[Authorize\] on Admin, dev admin account | Josh  | 2       | M    | Wed Nov 25 |
| 4   | Layout and shared UI: \_Layout, nav styling, site.css, \_Flash partial, remove jQuery and validation scripts (spec forbids JavaScript)                                                                          | Sarah | 1       | M    | Tue Nov 24 |
| 5   | Test data: her share of the shared teams and players spreadsheet                                                                                                                                                | Erika | none    | M    | Wed Nov 25 |
| 6   | Home page with group details (HomeController Index)                                                                                                                                                             | Erika | 1       | S    | Wed Nov 25 |
| 7   | MVC-01 Register Team                                                                                                                                                                                            | Sarah | 3       | L    | Fri Nov 27 |
| 8   | MVC-06 Create Team                                                                                                                                                                                              | Sarah | 3       | M    | Tue Dec 1  |
| 9   | MVC-10 Mark Team as Paid                                                                                                                                                                                        | Erika | 3       | S    | Mon Nov 30 |
| 10  | MVC-02 View Paid Teams                                                                                                                                                                                          | Sarah | 3       | S    | Mon Nov 30 |
| 11  | MVC-03 View Team Details                                                                                                                                                                                        | Sarah | 3       | S    | Mon Nov 30 |
| 12  | MVC-07 Edit Team                                                                                                                                                                                                | Josh  | 3       | M    | Mon Nov 30 |
| 13  | MVC-11 Filter Teams (Admin Index)                                                                                                                                                                               | Erika | 3       | M    | Tue Dec 1  |
| 14  | MVC-08 Delete Team (confirm page, removes players)                                                                                                                                                              | Erika | 3       | S    | Tue Dec 1  |
| 15  | MVC-09 Manage Players                                                                                                                                                                                           | Sarah | 3       | L    | Thu Dec 3  |
| 16  | MVC-12 Registration Summary                                                                                                                                                                                     | Erika | 3       | M    | Wed Dec 2  |
| 17  | Seed script database/02\_seed\_data.sql from the shared spreadsheet, plus rebuild-from-scratch test                                                                                                             | Erika | 2, 5    | M    | Thu Dec 3  |
| 18  | MVC-13 Division Summary (bonus)                                                                                                                                                                                 | Erika | 16      | M    | Mon Dec 7  |
| 19  | Robustness pass: bad IDs return NotFound(), URL manipulation, duplicate names, bypass attempts. Erika leads and keeps the test checklist; each person fixes bugs in their own files                             | All   | 1 to 17 | M    | Tue Dec 8  |
| 20  | UI and UX polish: confirmations, clear error messages, consistent navigation                                                                                                                                    | Sarah | 19      | M    | Wed Dec 9  |
| 21  | Final README: team members, features, controller structure, how to rebuild the database                                                                                                                         | Erika | 19      | S    | Wed Dec 9  |
| 22  | Rehearsal: demo script for Part A, each person explains their own code, everyone practises Part B questions                                                                                                     | All   | 20, 21  | M    | Thu Dec 10 |

**Why nobody is blocked in the first two days:** only issue 1 (a few hours) gates the others. Sarah's layout work (4) and Erika's test data and Home page work (5, 6) do not need the models. By Wednesday the skeleton exists and every Phase 1 issue can start in parallel.

## 5. Rules that keep everyone unblocked

1. **Contracts first.** Josh fixes the ViewModels, routes, nav links and TempData keys (Success and Error) in the skeleton. Everyone else codes against those names and does not rename them without asking.
2. **Small PRs.** One use case per PR, ideally under 300 changed lines. Title starts with the use case ID, for example `MVC-07: Edit Team`.
3. **24-hour review promise.** Josh checks open PRs at two fixed times a day (suggested: morning and evening). If a PR has waited more than 24 hours, the author comments on it to ping him.
4. **Approve with nits.** If a PR only has minor style notes, the reviewer approves and the author fixes them in the next PR. Only real bugs and spec violations block a merge.
5. **Never wait on a review.** Start the next issue from a fresh `main`. Do not build one branch on top of another unmerged branch.
6. **Authors merge their own PRs.** After approval, the author clicks Squash and merge (or turns on auto-merge). Josh approves once and does not need to merge.
7. **Schema changes go through Josh only.** Change `database/01_schema.sql` and the models together in one PR, and announce it in chat. Do not use EF migrations (their snapshot file causes painful conflicts). Never commit `bowling.db`; each person rebuilds it from the SQL scripts.
8. **Shared files** (Program.cs, Models, \_Layout) are changed only in tiny, separate PRs, announced in chat first.
9. **Blocked for more than 30 minutes?** Use the Blocked form (section 7), then move to your next issue. Whoever is tagged replies within 4 working hours.
10. **Sync every session.** Start each work session with `git checkout main` and `git pull origin main`.
11. **Josh's PRs are approved by Sarah** (Erika as backup), so Josh is never waiting on himself.

## 6. One-time GitHub setup (Josh)

1. **Create the repository** and push the scaffold from issue 1 directly to `main`. Do this before turning on the rules below.
2. **Invite Sarah and Erika** under Settings, Collaborators, with the **Write** role.
3. **Repository settings** (Settings, General, Pull Requests):
    - Allow squash merging only.
    - Turn on Automatically delete head branches.
    - Turn on Allow auto-merge.
4. **Protect main** (Settings, Rules, Rulesets, New branch ruleset, target the default branch):
    - Require a pull request before merging, with **1 approval**.
    - Leave Dismiss stale approvals **off** and Require review from Code Owners **off**. Both cause extra re-reviews and would stop Sarah from approving Josh's PRs.
    - Require status checks to pass, and select the **Build** check (see Appendix).
    - Block force pushes.
    - Add yourself to the bypass list for emergencies only.
5. **Add the files in the Appendix** to the repo (issue forms, PR template, CODEOWNERS, build workflow). Issue forms live in `.github/ISSUE_TEMPLATE/`.
6. **Create labels:** `task`, `blocked`, `bug`, `bonus`, `area:auth`, `area:public`, `area:admin`, `area:ui`, `area:data`, `area:docs`.
7. **Create a GitHub Project** (Board layout) with columns Todo, In Progress, In Review, Done. Turn on the built-in workflows so closing an issue moves the card to Done automatically.
8. **Create issues 1 to 22** from the Task form. Set the assignee, the area label and the Needs field from section 4.

## 7. Day-to-day guide for every team member

### Starting a task

1. Open the Project board, take the top Todo issue assigned to you, and drag it to In Progress.
2. Create your branch from an up-to-date `main`:

```bash
git checkout main
git pull origin main
git checkout -b feature/mvc-01-register-team
```

Branch names: `feature/mvc-XX-short-name` for use cases, `chore/...` for setup, `docs/...` for documentation.

### While working

- Commit often with clear messages, for example `git commit -m 'MVC-01: validate duplicate team name'`.
- Check your use case against the Details spec: the HTTP verbs, the validation, and the `NotFound()` check for any action that takes an id.
- Use ViewModels in views and forms, not entities. Use the `_Flash` partial and the TempData keys for success and error messages.
- No JavaScript and no client-side validation anywhere.

### Opening a PR

```bash
git push -u origin feature/mvc-01-register-team
```

1. On GitHub, click Compare and pull request. The PR template appears; fill it in and keep `Closes #7` (your issue number) so the issue closes on merge.
2. Josh is requested as reviewer automatically. Move your card to In Review.
3. Pick up your next issue straight away; do not wait.

### After review

- **Changes requested:** push more commits to the same branch. The PR updates itself.
- **Approved:** click Squash and merge. The branch is deleted automatically. Then run:

```bash
git checkout main
git pull origin main
```

### If you are blocked

1. On GitHub go to Issues, New issue, **Blocked / Need help**. Name who can unblock you and what you will work on meanwhile.
2. Post a one-line message in the group chat linking it.
3. Switch to your next issue. Do not sit idle.

### Optional peer review

Sarah and Erika are encouraged to leave comments on each other's PRs. Only Josh's approval (or Sarah's on Josh's PRs) is required, so comments never hold up a merge. Reading each other's code also prepares everyone for Part B of the presentation, where the instructor asks questions about the code.

## 8. Local setup (everyone)

1. Install Git, the .NET 10 SDK, the `sqlite3` command-line tool, and Visual Studio or VS Code.
2. Clone the repo and open the solution:

```bash
git clone <repo-url>
cd <repo-folder>
```

3. Build the database from the scripts (the spec puts `bowling.db` in the AppData folder):

```bash
sqlite3 AppData/bowling.db < database/01_schema.sql
sqlite3 AppData/bowling.db < database/02_seed_data.sql
```

Until issue 17 is merged there is no seed file, so skip the second command and add a few teams by hand. 4. Run the app with `dotnet run`. The README lists the development admin login created in issue 3. 5. If the schema changes, delete your local `bowling.db` and rebuild it from the scripts.

## 9. Review checklist and definition of done

A PR is ready to approve when:

- [ ] It builds, and the Build check is green.
- [ ] It matches the use case in the Details spec (HTTP verbs, behaviour, business rules).
- [ ] Validation errors show clearly in the UI.
- [ ] Any action with an id returns `NotFound()` when the record does not exist.
- [ ] Admin actions sit behind login.
- [ ] ViewModels are used, controllers stay thin, views use the shared layout and tag helpers.
- [ ] A flash message confirms success or reports an error.
- [ ] There is no JavaScript, no client-side validation, no committed database file, no leftover debug code.
- [ ] The PR is small and focused on one use case.

Business rules to keep in mind while reviewing: $200 fee, exactly four players per team, unique team names, only paid teams appear on the public list, and fee and payment date are required only when a team is marked paid.

## 10. Weekly rhythm

| When     | What                                                                                                                                     |
| -------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| Monday   | 15-minute check-in: what is next, any blockers. Josh confirms the week's issues are on the board.                                        |
| Daily    | Josh reviews PRs at his two fixed times. Everyone pulls `main` before starting.                                                          |
| Thursday | Josh drafts the status report from the board (done, next, blockers). Sarah and Erika review it and add anything missing.                 |
| Friday   | Josh submits the final status report (Nov 27, Dec 4, Dec 11). Confirm with the instructor whether reports go in per group or per person. |

## Appendix: files to add to the repository

### .github/ISSUE\_TEMPLATE/config.yml

```yaml
blank_issues_enabled: false
```

### .github/ISSUE\_TEMPLATE/task.yml

```yaml
name: Task
description: A unit of work, usually one use case
title: "MVC-XX: "
labels: ["task"]
body:
    - type: input
      id: use-case
      attributes:
          label: Use case ID
          placeholder: MVC-07
    - type: textarea
      id: description
      attributes:
          label: What needs to be done
      validations:
          required: true
    - type: textarea
      id: acceptance
      attributes:
          label: Acceptance criteria
          value: |
              - [ ] Works as described in the Details spec
              - [ ] Validation errors are shown in the UI
              - [ ] Unknown ids return NotFound()
              - [ ] Flash message on success or error
      validations:
          required: true
    - type: input
      id: needs
      attributes:
          label: Needs (issue numbers, or none)
      validations:
          required: true
    - type: dropdown
      id: size
      attributes:
          label: Size
          options:
              - "S (under 1 hour)"
              - "M (half a day)"
              - "L (a day or more)"
```

### .github/ISSUE\_TEMPLATE/blocked.yml

```yaml
name: Blocked / Need help
description: Use this when you are stuck for more than 30 minutes
title: "BLOCKED: "
labels: ["blocked"]
body:
    - type: input
      id: related
      attributes:
          label: Related issue or PR
      validations:
          required: true
    - type: textarea
      id: problem
      attributes:
          label: What is blocking you
          description: Include error messages and what you already tried.
      validations:
          required: true
    - type: dropdown
      id: who
      attributes:
          label: Who can unblock you
          options:
              - Josh
              - Sarah
              - Erika
      validations:
          required: true
    - type: input
      id: meanwhile
      attributes:
          label: What you are working on meanwhile
```

### .github/ISSUE\_TEMPLATE/bug.yml

```yaml
name: Bug
description: Something does not behave as the spec says
title: "BUG: "
labels: ["bug"]
body:
    - type: input
      id: use-case
      attributes:
          label: Use case ID
    - type: textarea
      id: steps
      attributes:
          label: Steps to reproduce
      validations:
          required: true
    - type: textarea
      id: expected
      attributes:
          label: Expected and actual behaviour
      validations:
          required: true
```

### .github/pull\_request\_template.md

```markdown
## What this PR does

Closes #

## Use case

MVC-XX

## How to test

1.
2.

## Checklist

- [ ] Builds locally
- [ ] Matches the Details spec
- [ ] Validation errors shown in the UI
- [ ] NotFound() for unknown ids
- [ ] No JavaScript, no committed .db file
```

### .github/CODEOWNERS

```
* @joshieingold
```

### .github/workflows/build.yml

```yaml
name: Build
on:
    pull_request:
        branches: [main]
jobs:
    build:
        runs-on: ubuntu-latest
        steps:
            - uses: actions/checkout@v4
            - uses: actions/setup-dotnet@v4
              with:
                  dotnet-version: 10.0.x
            - run: dotnet build --nologo
```

### .gitignore additions

```

bin/
obj/
AppData/*.db
AppData/*.db-*
.vs/
```

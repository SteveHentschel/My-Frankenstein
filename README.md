My-Frankenstein
===============

My first pet project: a Monster Database using C# .NET MVC3 w/ SQL Express in Visual Studio 2010.

MF Rev 1.2.0 -- (11/17/13)
- Added image file upload/change process to Edit; added file error processing to Edit/Create
- Added image file type check (png, jpg, gif) and file size check (<1Mb) with error msgs
- Now deletes old image file from ~/Content/Images on Delete or when image is changed in Edit
- Added 'redirect to calling view' when logging in (harder than it sounds)
-- Still need to add thumbnail processing, Quick Index, and then beautify.  slh

MF Rev 1.1.0 -- (11/15/13)
- Added image file upload process to Create (still working on Edit)
- Added image displays to Details and Delete views
-- Working on image file in Edit (no upload if not changed), and deleting image file when monster record is Deleted.  slh

MF Rev 1.0.0 -- Base (11/13/13)
- Initial monster database, allocated DB and classes, basic CRUD working
- User login check to create records, user match in place to edit/delete records.
- Images not implemented yet, still not pretty.  slh



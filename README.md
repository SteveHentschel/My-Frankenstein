My-Frankenstein
===============

My first pet project: a Monster Database using C# .NET MVC3 w/ SQL Express in Visual Studio 2010.

MF Rev 1.5.0 -- (11/21/13)
- Deploy finished; only minor issues, easily fixed (Praise be to Arvixe and VS Web Deploy!)
- One suggestion: don't mess with db's in App_Data, especially user instances.
- Fixed some minor styling issues seen on non-Firefox browsers (checked IE and Chrome).
- That's it for now; any suggestions or issues, send an email to slhcoding@gmail.com.  slh

MF Rev 1.4.0 -- (11/20/13)
- Done with beautifying (harder than expected); lots of nit-picky stuff in css and views.
- Changed color scheme and added static site images.
- Next/Last: Deploy to new Arvixe hosting site (will be hard, I think). 
- Site name:  myfrankenstein.net

MF Rev 1.3.0 -- (11/18/13)
- Added Quick Index (list) for longer lists with search function (from J Popovic tutorial)
- Added thumbnail processing in Create/Edit, also display Thumbs in regular index.
- Next: working on formatting/beauty now, then time to deploy

MF Rev 1.2.0 -- (11/17/13)
- Added image file upload/change process to Edit; added file error processing to Edit/Create
- Added image file type check (png, jpg, gif) and file size check (<1Mb) with error msgs
- Now deletes old image file from ~/Content/Images on Delete or when image is changed in Edit
- Added 'redirect to calling view' when logging in (harder than it sounds)
- Next:  add thumbnail processing, Quick Index, and then beautify.  slh

MF Rev 1.1.0 -- (11/15/13)
- Added image file upload process to Create (still working on Edit)
- Added image displays to Details and Delete views
- Next:  image file in Edit (no upload if not changed), and delete image file when monster record is Deleted.  slh

MF Rev 1.0.0 -- Base (11/13/13)
- Initial monster database, allocated DB and classes, basic CRUD working
- User login check to create records, user match in place to edit/delete records.
- Next: Images not implemented yet, still not pretty.  slh



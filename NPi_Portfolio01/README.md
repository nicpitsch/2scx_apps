# NPi_Portfolio01

#### Purpose
Present some structured content with any number of images presented as gallery.
![Sample portfolio](https://raw.github.com/nicpitsch/2scx_apps/master/NPi_readme-assets/2015-12-31_04-21-05.jpg)

Based on the following information from 2sxc.org:
* [WebApi demo-apps](http://2sxc.org/en/apps/tag/WebApi).
* [WebAPI - Automatic WebServices for your Apps](http://2sxc.org/en/Docs-Manuals/Feature/feature/3361).
* [Menus for Item-Actions in HTML and JS (manage.getToolbar)](http://2sxc.org/en/Docs-Manuals/Menu-for-Item-Actions-like-New-Edit).
* [Also Create Templates and Views using Tokens](http://2sxc.org/en/Learn/Token-Templates-and-Views).

#### Dependencies

Front-End framework [EmberJs](http://emberjs.com/), install:
* _bower install ember#1.13_.
* Take from there _ember.min.js_ and _ember-template-compiler.js_.
* [Minify](http://refresh-sf.com/) _ember-template-compiler.js_ to _ember-template-compiler.min.js_.

Photo gallery [blueimp Gallery](https://blueimp.github.io/Gallery/):
* Setup according to [setup](https://github.com/blueimp/Gallery/blob/master/README.md#setup) and [jquery plugin](https://github.com/blueimp/Gallery/blob/master/README.md#jquery-plugin).
* Place those dependencies in the _[App:Path]/assets/blueimp-gallery_ folder, or if you intend to use this gallery for the whole Portal at _[Portal:HomeDirectory]/assets/blueimp-gallery_.
* Take the _demo.css_ as example, modify it and copy it to the _assets_ folder (name it blueimp.css e.g.)

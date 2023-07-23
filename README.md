# n-optional

Exposes an `Option` type for use in unity3d.

If you don't have the JSON.Net namespace, delete this or reference it in the package manager.

see: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-official-via-UPM#installing-the-package-via-upm-window

## Usage

See the tests in the `Editor/` folder for each class for usage examples.

## Install

From your unity project folder:

    npm init
    npm install shadowmint/unity-n-optional --save
    echo Assets/pkg-all >> .gitignore
    echo Assets/pkg-all.meta >> .gitignore

The package and all its dependencies will be installed in
your Assets/pkg-all folder.

## Development

Setup and run tests:

    cd test
    npm install

Remember that changes made to the test folder are not saved to the package
unless they are copied back into the source folder.

To reinstall the files from the src folder, run `npm install ..` again.

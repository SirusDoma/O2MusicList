# O2Jam Music List #
O2Jam Music List Generator.  
Support new and old OJNList format.

- **Author**: SirusDoma
- **Email**: com@cxo2.me
- **Latest Version**: 1.8

## Summary ##

O2Jam Music List is an utility to either create or modify OJNList file.  
Currently support both format: Chinese and Korean OJNList as well as encrypting / decrypting OJN files.

By default, this program will attempt to synchronize between OJNList and OJN files to save your time from inconsistency data. There are various build options to try.  

Special thanks to Kishi, Dugi, Lujia and arcmess.
This program requires .NET 4.6.1 in order to run properly.

## Setup Character Encoding ##

You can enforce specific character encoding of your choice for entire OJNList. This encoding be used to encode song title, artists, note arranger and ojm filename. To override default encoding, click File -> Preference then uncheck "Auto detect character encoding from OJNList version".  

Select the desired encoding from the drop down list, additionally, you can supply encoding name, here the list of supported encoding names:    

https://docs.microsoft.com/en-us/windows/desktop/intl/code-page-identifiers

Note that you can override this on per song basis by selecting preferred encoding that located on right side of title field.

## Creating / Loading OJNList File ##

Click File -> New to create a new OJNList, you can select OJNList format in File -> Preference and uncheck "Preserve original format" then select preferred OJNList format.

To open existing file, click File -> Open.

## Manipulating OJNList data ##

In order to add OJN files into OJNList, click Add button then select OJN files to add.
Note that you can select multiple files at a time, you can either select decrypted or encrypted OJN file. To remove OJN from OJNList, select songs to remove (hold CTRL to select multiple songs) and click Remove button.  

You can also modify OJN metadata by selecting desired song and modify the fields on the right side of application. By default, the program will attempt to modify OJN file as well, you can turn off this feature in File -> Preference and uncheck "Attempt to synchronize OJN file".

## Optimizing Music List ##

Often songs data get duplicated due to e-Games and Nowcom versioning. This getting worse when the song is exactly the same but contain different ID to each other. To remove such files Edit -> Remove duplicate. This will multiple songs with same song title.  

Setting up key mode for every 3K and 5K chart are tedious things to do. To make this process easier, use key mode correction. It simply convert all songs with [3K] / [3M] / [3D] tags to 3K mode, this apply to 5K as well. To use this feature, select Edit -> Autocorrect KeyMode.  

By default, the program will attempt to auto correct the key mode and will NOT remove duplicate headers upon loading existing file, this behavior can be changed in File -> Preference.

## Encrypting / Decrypting OJN Files ##

The program provide convenient way to encrypt / decrypt OJN via Tools -> Encrypt / Decrypt OJN. You will prompted to select OJN files to convert then select output directory where encrypted / decrypted OJN will be dumped.  

This will convert old OJN into new OJN and vice versa.

## Dependencies ##
- Fody
- Fody.Costura
- Newtonsoft.Json

## License ##

This is an open-sourced application licensed under the [MIT License](http://github.com/SirusDoma/O2MusicList/blob/master/LICENSE).

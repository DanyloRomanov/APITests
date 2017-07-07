Feature: GetFileList
	
@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@Upload
Scenario: Upload a file
	Given I have 'MyPdf.pdf' file to upload
	When I upload the file
	| Path        | Mode | AutoRename | Mute  |
	| /MyFile.pdf | add  | true       | false |
	Then I should be able to get file info
	| Name       |
	| MyFile.pdf |

@CreateFolder
Scenario: Create a folder
Given I send reqest to create a folder
When I try to get list of all existing files
Then I  should get my folderin list of folders

@RemoveFolder
Scenario: Delete Folder
Given I send request to delete folder
When I try to get list of all existing files
Then I should not get my folderin list of folders
And I Should get error when try to get deleted folder

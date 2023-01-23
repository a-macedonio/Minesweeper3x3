
# Minesweeper 3X3

Minesweeper game in a 3X3 board written  in C#


## Installation

The project runs on Microsoft Visual Studio. You can download the community (free) version from this link: 
https://visualstudio.microsoft.com/downloads/

Once Visual Studio is installed, just double click on the solution file (Minesweeper.sln) and the complete project will be loaded and ready to run.


    
## Features
- The user can manually assign where the mines will be located or let the computer do it. In any case, the mine board is always stored in an xml file as shown in the example below:

    ```xml
        <Fields>
            <Field row="0" column="0">
                <Mine active="no" />
            </Field>
            <Field row="0" column="1">
                <Mine active="no" />
            </Field>
            <Field row="0" column="2">
                <Mine active="yes" />
            </Field>
            <Field row="1" column="0">
                <Mine active="no" />
            </Field>
            <Field row="1" column="1">
                <Mine active="yes" />
            </Field>
            <Field row="1" column="2">
                <Mine active="no" />
            </Field>
            <Field row="2" column="0">
                <Mine active="yes" />
            </Field>
            <Field row="2" column="1">
                <Mine active="no" />
            </Field>
            <Field row="2" column="2">
                <Mine active="no" />
            </Field>
        </Fields>
    ```
- In playing mode, user can play a move or pass the move to the CPU.
- Each move of the game can be stored in an XML file as shown in the example below:

    ```xml
        <Game>
            <Move>
                <Step id="1" time="00:02">
                    <Player type="computer" />
                    <Play>[0, 1]</Play>
                </Step>
                <Step id="2" time="00:05">
                    <Player type="user" />
                    <Play">[0, 2]</Play>
                </Step>
            </Move>
        </Game>
    ```

## Screenshots

![image](https://user-images.githubusercontent.com/120599480/213951302-b9ea5304-a162-4869-bdf4-1d0a35b02ad9.png)
![image](https://user-images.githubusercontent.com/120599480/213951358-35ca93df-0946-4b1f-94bf-4260b3aa7b04.png)
![image](https://user-images.githubusercontent.com/120599480/213951424-0d2c6994-502d-45d6-a0e7-596ffefe3a95.png)
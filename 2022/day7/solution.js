const data = [
	'$ cd /',
	'$ ls',
	'dir a',
	'14848514 b.txt',
	'8504156 c.dat',
	'dir d',
	'$ cd a',
	'$ ls',
	'dir e',
	'29116 f',
	'2557 g',
	'62596 h.lst',
	'$ cd e',
	'$ ls',
	'584 i',
	'$ cd ..',
	'$ cd ..',
	'$ cd d',
	'$ ls',
	'4060174 j',
	'8033020 d.log',
	'5626152 d.ext',
	'7214296 k'
]
/*
        da data deve uscire questo:

const / = {
    name: '/',
    filesSize: [14848514, 8504156],
    parents: '',
    children: [
        {
            name: 'a',
            filesSize: [29116, 2557, 62596],
            parents: '/',
            children: [
                {
                    name: 'e',
                    filesSize: [584],
                    parents: 'a',
                    children: []
                }
            ]
        }, {
            name: 'd',
            filesSize: [4060174, 8033020, 5626152, 7214296],
            parents: '/',
            children: []
        }
    ]
}
*/
//CLASS STATEMENT
class Directory {
    constructor(name, parent = "", filesSize = [], children = []){
        this.name = name;
        this.children = children;
        this.filesSize = filesSize;
        this.parent = parent;
    }
    
    addFile(size) {
        this.filesSize.push(size);
    }
    
    addChildren(constructor) {
        this.children.push(constructor);
    }

    getFilesSize(){
        return Object.values(this.filesSize).reduce((x, y) => x + y) + Object.values(this.children).map((child) => child.getFilesSize()).reduce((x, y) => x + y)
    }
}

//TURN DATA INTO OBJECT
function setDirectory(data){
	const directory = new Directory('/')
    let currentDirectory =  directory
		
    data.forEach((command) => {
        if(command.startsWith('$ cd')){
            const destinationFolder  = command.slice(5) 
            if(destinationFolder  === '..'){currentDirectory = currentDirectory.parent}
            else{currentDirectory = currentDirectory.children[destinationFolder]}
            console.log(currentDirectory)
        } else if (command.startsWith('dir')){
            const child = new Directory(command.slice(4), currentDirectory)
            currentDirectory.addChildren(child)
            console.log('|||||', currentDirectory.children)
        } else if(!command.startsWith('$ ls')){
            const size = Number(command.split(' ')[0])
            console.log('-----', currentDirectory.filesSize)
            //currentDirectory.filesSize.push(size)
        }
    })

    return (directory.children)
}

console.log(setDirectory(data))

/* 
function terminalTranslator() {
    const commandLine = fileToArr("input");
    const root = new Directory("/");
    let currentDirectory = root;

    commandLine.forEach((command) => {
        
        } else if (command.startsWith("dir")) {
            const dirName = command.slice(4);
            currentDirectory.children[dirName] = new Directory(
                dirName,
                currentDirectory
            );
        } else {
            const [fileSize, fileName] = command.split(" ");
            currentDirectory.addFile(fileName, Number(fileSize));
        }
    });
    return root;
}
*/
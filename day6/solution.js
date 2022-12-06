import datastreamBuffer from './data'

const checkPacket = (string, characters) => {
	let splittedItem = [...string]
    let indexToAdd = 0
    let checkMarkerArray = []

    for(let i = indexToAdd; i < indexToAdd + characters; i++){
        checkMarkerArray.push(splittedItem[i])

        if(checkMarkerArray.length === characters){
            if(checkMarkerArray.filter((item, index) => checkMarkerArray.indexOf(item) !== index).length > 0){
                checkMarkerArray.shift()
                indexToAdd++
            } else {
                return indexToAdd + characters
            }
        }
    }
}

//RESULTS
console.log(
    checkPacket(datastreamBuffer, 4), //PART ONE
    checkPacket(datastreamBuffer, 14) //PART TWO
)
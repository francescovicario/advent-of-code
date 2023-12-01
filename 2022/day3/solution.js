import { alphabet, data } from './data'

//FIRST PART
const sharedItems = data.map(item => {
	let firstRucksack = [...item.substring(0, item.length/2)]
	let secondRucksack = [...item.substring(item.length/2, item.length)]

	for(let letter of firstRucksack){
		if(secondRucksack.includes(letter)){
			return alphabet.indexOf(letter)
		}
	}
})

//SECOND PART
const getGroupedDataBadges = (data) => {
	let groupedData = []
	let j = -1
	
	for (let i = 0; i<data.length; i++){
		if(i % 3 === 0) {
			j++
			groupedData.push([])
		}
		groupedData[j].push(data[i])
	}
	
	return groupedData.map(item => {
		const firstWord = [...item[0]]
		const secondWord = [...item[1]]
		const thirdWord = [...item[2]]

		for(let letter of firstWord){
			if(secondWord.includes(letter) && thirdWord.includes(letter)){
				return alphabet.indexOf(letter)
			}
		}
	})
}

//RESULTS
console.log(sharedItems.reduce((a, b) => a + b), getGroupedDataBadges(data).reduce((a, b) => a + b))

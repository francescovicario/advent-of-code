import data from './data'

//PART ONE
const getFullyContainedAssignment = data.map(item => {
	const firstArray = item[0]
    const secondArray = item[1]

    if ((firstArray[0] >= secondArray[0] && firstArray[1] <= secondArray[1]) || (firstArray[0] <= secondArray[0] && firstArray[1] >= secondArray[1])) {return 1} else {return 0}
})

//PART TWO
const getPartiallyContainedAssignments = data.map(item => {
	const firstItem = item[0]
    const secondItem = item[1]

    if (firstItem[1] >= secondItem[0] && secondItem[1] >= firstItem[0]) {return 1} else {return 0}
})

//RESULTS
console.log(
    getFullyContainedAssignment.filter(item => item === 1).length,
    getPartiallyContainedAssignments.filter(item => item === 1).length
)
import { data } from './data'

//PART ONE

const finalResults = data.map(arr => {
	switch(arr[0]){
        case 'A':
            switch(arr[1]){
                case 'X':
                    return 4
                    break
                case 'Y':
                    return 8
                    break
                case 'Z':
                    return 3
                    break
            }
            break
        case 'B':
            switch(arr[1]){
                case 'X':
                    return 1
                    break
                case 'Y':
                    return 5
                    break
                case 'Z':
                    return 9
                    break
            }
            break
        case 'C':
            switch(arr[1]){
                case 'X':
                    return 7
                    break
                case 'Y':
                    return 2
                    break
                case 'Z':
                    return 6
                    break
            }
        	break
    }
})

//PART TWO

const alternativeFinalResults = data.map(arr => {
	switch(arr[0]){
        case 'A':
            switch(arr[1]){
                case 'X':
                    return 3
                    break
                case 'Y': 
                    return 4
                    break
                case 'Z':
                    return 8
                    break
            }
            break
        case 'B':
            switch(arr[1]){
                case 'X':
                    return 1
                    break
                case 'Y':
                    return 5
                    break
                case 'Z':
                    return 9
                    break
            }
            break
        case 'C':
            switch(arr[1]){
                case 'X':
                    return 2
                    break
                case 'Y':
                    return 6
                    break
                case 'Z':
                    return 7
                    break
            }
            break
    }
})

//RESULTS

console.log(finalResults.reduce((a, b) => a + b), alternativeFinalResults.reduce((a, b) => a + b))

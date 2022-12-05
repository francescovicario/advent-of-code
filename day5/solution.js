import { cargoStacks, instructions } from './data'

//PART ONE
function craneOperatorOne(){
    let topCrates = ''

    for(let item of instructions){
        for (let i = 0; i < item[0]; i++){
            cargoStacks[item[2]].push(cargoStacks[item[1]].pop())
        }
    }
    
    for (const [key, value] of Object.entries(cargoStacks)) {
        topCrates += value[value.length-1]
    }

    return topCrates
}

//PART TWO
function craneOperatorTwo(){
    let topCrates = ''
    
    instructions.map(item => {
        let setOrder = []
        for (let i = 0; i < item[0]; i++){
            if(item[0] === 1){
                cargoStacks[item[2]].push(cargoStacks[item[1]].pop())
            } else {
                setOrder.push(cargoStacks[item[1]].pop())
                if(setOrder.length === item[0]){
                    for(let j = 0; j < setOrder.length; i++){
                        cargoStacks[item[2]].push(setOrder.pop())
                    }
                }
            }
        }
    })
    
    
    for (const [key, value] of Object.entries(cargoStacks)) {
        topCrates += value[value.length-1]
    }

    return topCrates
}

//RESULTS
console.log(craneOperatorOne(), craneOperatorTwo())
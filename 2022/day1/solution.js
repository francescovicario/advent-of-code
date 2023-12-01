import { data } from './data'

let sum = []
let a 
for (let i = 0; i < data.length; i++){
  if(typeof data[i] === 'number'){
   	(typeof data[i-1] === 'string' || i-1 < 0) ? a = data[i] : a += data[i]
  } else {
  	sum.push(a)
   	a = 0
  }
  i+1 === data.length && sum.push(a)
}


sum.sort((a, b) => b - a)

const get3HighestNumbersSum = sum => sum[0] + sum[1] + sum[2]

//results
console.log(sum[0],  get3HighestNumbersSum(sum))

import moment from "moment";

function deepClone<T>(objectToClone: T): T {
    return JSON.parse(JSON.stringify(objectToClone))
}

function humanizeDate(dateTime: string){
    return moment(dateTime).format("DD. MM. YYYY")
}


export {
    deepClone,
    humanizeDate
}

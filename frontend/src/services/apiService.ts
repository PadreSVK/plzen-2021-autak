import axios, { AxiosRequestConfig, Method, AxiosError, Cancel } from "axios"
import { ValidationError, UnexpectedError } from "@/services/Errors"


const httpClient = axios.create();

async function axiosRequest(request: { method: Method, endpoint: string, axiosRequestConfig?: AxiosRequestConfig, body?: any }) {
    const requestUrl = `https://localhost:5001/api/${request.endpoint}`
    try {
        const response = await httpClient({
            ...request.axiosRequestConfig,
            method: request.method,
            url: requestUrl,
            data: request.body,
            //withCredentials: true
        })
        return response.data;
    }
    catch (error) {

        if (error as Cancel && !error.response) {
            // Cancel have only message property
            throw error
        }
        const axiosError = error as AxiosError;
        switch(axiosError.response?.status){
            case 401:
                console.log("non authenticated User")
                break
            case 422:
                throw new ValidationError(axiosError.response.data.message, axiosError.response.data.errors)
            default:
                throw new UnexpectedError(axiosError?.response?.data.message)

        }
    }
}

async function GET(endpoint: string, axiosRequestConfig?: AxiosRequestConfig) {
    return await axiosRequest({ method: "GET", endpoint, axiosRequestConfig })
}

async function POST(endpoint: string, body?: any, axiosRequestConfig?: AxiosRequestConfig) {
    return await axiosRequest({ method: "POST", endpoint, body, axiosRequestConfig })
}

async function PUT(endpoint: string, body: any, axiosRequestConfig?: AxiosRequestConfig) {
    return await axiosRequest({ method: "PUT", endpoint, body, axiosRequestConfig })
}

async function DELETE(endpoint: string, body?: any, axiosRequestConfig?: AxiosRequestConfig) {
    return await axiosRequest({ method: "DELETE", endpoint, body, axiosRequestConfig })
}

export { GET, POST, PUT, DELETE }

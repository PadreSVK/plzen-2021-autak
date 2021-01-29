
export class ValidationError extends Error {
    validationErrors: Array<Object>
    userFriendlyMessage: string;

    constructor(message : string, validationErrors: Array<Object>) {
        super(message)
        this.message = message
        this.validationErrors = validationErrors
        this.userFriendlyMessage = Object.values(this.validationErrors).join(" ");
        // the next line is important so that the ValidationError constructor is not part of the resulting stacktrace
        // this is NON standard (not in ECMA) function working only in V8/Chromium based browsers, see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Error 
        if ((Error as any).captureStackTrace) {
            (Error as any).captureStackTrace(this, ValidationError)
        }
    }
}

export class UnexpectedError extends Error {
    userFriendlyMessage: string;
    constructor(message:string) {
        super(message)
        this.message = message
        this.userFriendlyMessage = message;
        // the next line is important so that the ValidationError constructor is not part of the resulting stacktrace
        // this is NON standard (not in ECMA) function working only in V8/Chromium based browsers, see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Error 
        if ((Error as any).captureStackTrace) {
            (Error as any).captureStackTrace(this, ValidationError)
        }
    }
}
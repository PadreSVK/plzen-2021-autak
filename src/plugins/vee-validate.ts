import { extend, ValidationObserver, ValidationProvider } from "vee-validate";
import * as rules from "vee-validate/dist/rules";

import { VTextFieldValidateable } from "@/components/ValidateableComponents";

export default {
    apply(Vue: any) {
        Object.keys(rules).forEach((rule) => {
            extend(rule, (rules as any)[rule])
        })

        extend("mySecretRule", {
            message: "Field {_field_} nie je validny, musi byt vacsi ako 6 znakov",
            validate: value => value?.length > 6 
        })

        Vue.component("ValidationObserver", ValidationObserver)
        Vue.component("ValidationProvider", ValidationProvider)
        Vue.component("v-text-field-validateable", VTextFieldValidateable)
    }
}
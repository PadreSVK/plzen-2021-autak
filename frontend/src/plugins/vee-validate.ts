import { extend, ValidationObserver, ValidationProvider, localize } from "vee-validate";
import * as rules from "vee-validate/dist/rules";
import en from "vee-validate/dist/locale/en.json";
import cs from "vee-validate/dist/locale/cs.json";

import { VTextFieldValidateable } from "@/components/ValidateableComponents";

export default {
    apply(Vue: any) {
        Object.keys(rules).forEach((rule) => {
            extend(rule, (rules as any)[rule])
        })

        const csMessages = cs.messages as any;
        const enMessages = en.messages as any;
        csMessages.mySecretRule = "Field {_field_} nie je validny, musi byt vacsi ako 6 znakov";
        enMessages.mySecretRule = "Field {_field_} is not valid, must be greater that 6";

        localize('cs', cs);
        localize('en', en);

        extend("mySecretRule", {
            validate: value => value?.length > 6 
        })

        Vue.component("ValidationObserver", ValidationObserver)
        Vue.component("ValidationProvider", ValidationProvider)
        Vue.component("v-text-field-validateable", VTextFieldValidateable)
    }
}
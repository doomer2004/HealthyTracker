import * as yup from 'yup';
import { UpdateProductFormFields } from '../../models/form/auth/UpdateProductFromFields';
import { UpdateProductRequest } from '../../models/api/request/UpdateProductRequest';

const updateProductFormValidation = yup.object<UpdateProductRequest>().shape({
	volume: yup.number()
		 .required('Volume is required')
		 .min(1, 'Name must be at least 1 gr')
		 .max(5000, 'Name must not exceed 5000 gr')
});

export default updateProductFormValidation;
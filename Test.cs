//// თუ ნიშნები ემთხვევა
//if (isNegative == number.isNegative)
//{
//    // თუ პირველი რიცხვის სიგრძე მეტია/ტოლია მეორეზე
//    if (this > number)
//    {
//        // მივყვეთ მეორე რიცხვის სიგრძის მიხედვით
//        for (int i = 0; i < number.length; i++)
//        {
//            //შევკრიბოთ
//            digits[i] += number.digits[i];
//            // თუ მეტია 10-ზე გამოვაკლოთ 10 და გადავიტანოთ 1
//            if (digits[i] > 9)
//            {
//                digits[i] -= 10;
//                // ვამოწმებთ i + 1 ინდექსი არის თუ არა მასივში
//                if (i + 1 < length)
//                {
//                    digits[i + 1]++;
//                }
//                else
//                {
//                    digits[i + 1] = 1;
//                    length++;
//                }
//            }
//        }
//    }
//    // პირველი რიცხვი სიგრძით ნაკლებია მეორეზე
//    else
//    {
//        // ახლა უკვე მივყვეებით პირველ რიცხვს
//        for (int i = 0; i < length; i++)
//        {
//            // ვკრებთ
//            number.digits[i] += digits[i];

//            // ვამოწმებთ საჭიროა თუ არა გადატანა
//            if (number.digits[i] > 9)
//            {
//                number.digits[i] -= 10;
//                // კვლავ ვამოწმებთ i + 1 არის თუ არა ინდექსში
//                if (i + 1 < number.length)
//                {
//                    number.digits[i + 1]++;
//                }
//                else
//                {
//                    number.digits[i + 1] = 1;
//                    number.length++;
//                }
//            }
//        }
//        digits = number.digits;
//        length = number.length;
//    }
//}
//// თუ ნიშნებით განსხვავდებიან
//else
//{
//    if (isNegative)
//    {
//        if (length > number.length)
//        {
//            // subtract second number from first
//            for (int i = 0; i < number.length; i++)
//            {
//                digits[i] -= number.digits[i];
//                if (digits[i] < 0)
//                {
//                    digits[i] += 10;
//                    digits[i + 1]--;
//                }
//            }
//        }
//        // if second number is bigger
//        else
//        {
//            // subtract first number from second
//            for (int i = 0; i < length; i++)
//            {
//                number.digits[i] -= digits[i];
//                if (number.digits[i] < 0)
//                {
//                    number.digits[i] += 10;
//                    number.digits[i + 1]--;
//                }
//            }
//            digits = number.digits;
//            length = number.length;
//            isNegative = false;
//        }
//    }
//    // თუ პირველი რიცხვი სიგრძით მეტია მეორეზე
//    //if (length >= number.length)
//    //{
//    //    // მივყვებით მეორე რიცხვს
//    //    for (int i = 0; i < number.length; i++)
//    //    {
//    //        // ვაკლებთ
//    //        digits[i] -= number.digits[i];

//    //        // we need to consider the case when the result is negative
//    //        if (digits[i] < 0)
//    //        {
//    //            digits[i] += 10;
//    //            digits[i + 1]--;
//    //        }
//    //    }
//    //    // special case ჯამი არის 0
//    //    if (digits[length - 1] == 0)
//    //    {
//    //        isNegative = false;
//    //        // ვამცირებთ სიგრძეს
//    //        for (int i = length - 1; i > 0; i--)
//    //        {
//    //            if (digits[i] == 0)
//    //            {
//    //                length--;
//    //            }
//    //            else
//    //            {
//    //                break;
//    //            }
//    //        }
//    //    }
//    //}
//    //else
//    //{
//    //    for (int i = 0; i < length; i++)
//    //    {
//    //        number.digits[i] -= digits[i];
//    //        if (number.digits[i] < 0)
//    //        {
//    //            number.digits[i] += 10;
//    //            number.digits[i + 1]--;
//    //        }
//    //    }
//    //    digits = number.digits;
//    //    length = number.length;
//    //    isNegative = true;
//    //    if (digits[length - 1] == 0)
//    //    {
//    //        isNegative = false;
//    //        for (int i = length - 1; i > 0; i--)
//    //        {
//    //            if (digits[i] == 0)
//    //            {
//    //                length--;
//    //            }
//    //            else
//    //            {
//    //                break;
//    //            }
//    //        }
//    //    }
//    //}
//}


////    return false;
////}
////else if (a.isNegative && b.isNegative)
////{
////    if (a.length > b.length)
////    {
////        return false;
////    }
////    if (a.length < b.length)
////    {
////        return true;
////    }
////    for (int i = a.length - 1; i >= 0; i--)
////    {
////        if (a.digits[i] > b.digits[i])
////        {
////            return false;
////        }
////        if (a.digits[i] < b.digits[i])
////        {
////            return true;
////        }
////    }
////    return false;
////}
////return false;


////if (a.isNegative && !b.isNegative)
////{
////    return false;
////}
////else if (!a.isNegative && b.isNegative)
////{
////    return true;
////}
////else if (!a.isNegative && !b.isNegative)
////{
///


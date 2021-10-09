/*
 * Tencent is pleased to support the open source community by making InjectFix available.
 * Copyright (C) 2019 THL A29 Limited, a Tencent company.  All rights reserved.
 * InjectFix is licensed under the MIT License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
 * This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
 */

namespace IFix.Core
{
    public enum Code
    {
        Conv_I4,
        Unaligned,
        Ldelem_U4,
        Conv_Ovf_I8_Un,
        Callvirt,
        Ldind_I1,
        Conv_Ovf_U1,
        Stobj,
        Div,
        Ble,
        Ldsflda,
        Stind_I4,
        Localloc,
        Ldelem_I1,
        Neg,
        Mkrefany,
        Arglist,
        Ldelem_I,
        No,
        Stind_R4,
        Stelem_Any,
        Ldelem_R4,
        Ldelema,
        Ble_Un,
        Ldind_R4,
        Ldc_I8,
        Conv_Ovf_U8,
        Conv_I8,
        Unbox,
        Conv_Ovf_U_Un,
        Initobj,
        Conv_Ovf_I1,
        Conv_Ovf_I,
        Stelem_R8,
        Conv_Ovf_I4,
        Ldstr,
        Dup,
        Ldarg,
        Cpblk,
        Stelem_R4,
        Ldelem_Ref,
        Bge,
        Conv_I,
        Refanytype,
        Ldobj,
        Conv_Ovf_U8_Un,
        Stind_R8,
        Ldind_I,
        Stelem_I,
        Conv_U,
        Conv_Ovf_U2_Un,
        Bne_Un,
        Callvirtvirt,
        Ldind_U4,
        Clt,
        Br,
        Constrained,
        Ldftn,
        Rethrow,
        Ldelem_R8,
        Starg,
        Add_Ovf,
        Ldelem_U2,
        Beq,
        Brtrue,
        Stind_I,
        Volatile,
        Conv_Ovf_I8,
        Conv_Ovf_I4_Un,
        Shr,
        Ldc_I4,
        Ldsfld,
        Ldind_U2,
        Call,
        Ckfinite,
        Nop,
        CallExtern,
        Ldind_I8,
        Cgt,
        Ldind_I2,
        Newanon,
        Sub,
        Stelem_I8,
        Unbox_Any,
        Cgt_Un,
        Shr_Un,
        Break,
        Stind_I8,
        Stelem_I4,
        Stelem_I1,
        Jmp,
        Stind_I1,
        Bgt,
        Ldloc,
        Rem_Un,
        //Calli,
        Rem,
        Ldlen,
        Tail,
        Blt,
        Ldelem_I8,
        Refanyval,
        Mul,
        Conv_Ovf_U4,
        Ldc_R4,
        Div_Un,
        Conv_U2,
        Ldind_I4,
        Switch,
        Ldflda,
        Stind_I2,
        Stfld,
        Conv_I1,
        Or,
        Castclass,
        Sub_Ovf_Un,
        Conv_Ovf_I2,
        Ldvirtftn2,
        Isinst,

        //Pseudo instruction
        StackSpace,
        Conv_Ovf_U,
        Cpobj,
        Sub_Ovf,
        Stind_Ref,
        Conv_R4,
        Ldtype, // custom
        Endfilter,
        Box,
        Conv_U8,
        Conv_R8,
        Newarr,
        Clt_Un,
        Ldind_R8,
        Ldloca,
        Conv_Ovf_U2,
        Mul_Ovf,
        Endfinally,
        Stelem_Ref,
        Conv_U4,
        Conv_Ovf_I2_Un,
        Ldind_Ref,
        Ldnull,
        Add_Ovf_Un,
        Blt_Un,
        Xor,
        Ldelem_U1,
        Ldelem_I2,
        Stloc,
        Leave,
        Bgt_Un,
        Ldelem_I4,
        Shl,
        Mul_Ovf_Un,
        Conv_R_Un,
        Sizeof,
        Ldelem_Any,
        Ldfld,
        Conv_U1,
        Ldvirtftn,
        Conv_Ovf_I_Un,
        Ldind_U1,
        Conv_Ovf_U4_Un,
        Conv_I2,
        Throw,
        Ldarga,
        Ldtoken,
        Stsfld,
        And,
        Conv_Ovf_I1_Un,
        Conv_Ovf_U1_Un,
        Readonly,
        Brfalse,
        Ldc_R8,
        Stelem_I2,
        Ret,
        Not,
        Newobj,
        Pop,
        Add,
        Bge_Un,
        Ceq,
        Initblk,
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Instruction
    {
        /// <summary>
        /// 指令MAGIC
        /// </summary>
        public const ulong INSTRUCTION_FORMAT_MAGIC = 7112085897352026515;

        /// <summary>
        /// 当前指令
        /// </summary>
        public Code Code;

        /// <summary>
        /// 操作数
        /// </summary>
        public int Operand;
    }

    public enum ExceptionHandlerType
    {
        Catch = 0,
        Filter = 1,
        Finally = 2,
        Fault = 4
    }

    public sealed class ExceptionHandler
    {
        public System.Type CatchType;
        public int CatchTypeId;
        public int HandlerEnd;
        public int HandlerStart;
        public ExceptionHandlerType HandlerType;
        public int TryEnd;
        public int TryStart;
    }
}
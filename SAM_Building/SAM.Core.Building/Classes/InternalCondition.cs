﻿using Newtonsoft.Json.Linq;
using SAM.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Building
{
    public class InternalCondition : SAMObject, IBuildingObject
    {
        public InternalCondition(InternalCondition internalCondition)
            : base(internalCondition)
        {

        }

        public InternalCondition(Guid guid, InternalCondition internalCondition)
        : base(guid, internalCondition)
        {

        }

        public InternalCondition(string name, InternalCondition internalCondition)
            : base(name, internalCondition)
        {

        }

        public InternalCondition(string name, Guid guid, InternalCondition internalCondition)
            : base(name, guid, internalCondition)
        {

        }

        public InternalCondition(Guid guid, string name)
            : base(guid, name)
        {

        }

        public InternalCondition(string name)
            : base(name)
        {
        }

        public InternalCondition(JObject jObject)
            : base(jObject)
        {
        }

        public string GetProfileName(ProfileType profileType)
        {
            InternalConditionParameter? internalConditionParameter = Query.InternalConditionParameter(profileType);
            if (internalConditionParameter == null || !internalConditionParameter.HasValue)
            {
                return null;
            }

            return GetValue<string>(internalConditionParameter.Value);
        }

        public bool SetProfileName(ProfileType profileType, string name)
        {
            InternalConditionParameter? internalConditionParameter = Query.InternalConditionParameter(profileType);
            if (internalConditionParameter == null || !internalConditionParameter.HasValue)
            {
                return false;
            }

            return SetValue(internalConditionParameter.Value, name);
        }

        public string GetSystemTypeName<T>() where T : ISystemType
        {
            if (typeof(T) == typeof(VentilationSystemType))
                return GetValue<string>(InternalConditionParameter.VentilationSystemTypeName);

            if (typeof(T) == typeof(CoolingSystemType))
                return GetValue<string>(InternalConditionParameter.CoolingSystemTypeName);

            if (typeof(T) == typeof(HeatingSystemType))
                return GetValue<string>(InternalConditionParameter.HeatingSystemTypeName);

            return null;
        }

        public IEnumerable<ProfileType> GetProfileTypes()
        {
            return GetProfileTypeDictionary()?.Keys;
        }

        public Dictionary<ProfileType, string> GetProfileTypeDictionary()
        {
            Dictionary<ProfileType, string> result = new Dictionary<ProfileType, string>();

            foreach (ProfileType profileType in Enum.GetValues(typeof(ProfileType)))
            {
                if (profileType == ProfileType.Other || profileType == ProfileType.Undefined)
                    continue;

                string name = GetProfileName(profileType);
                if (string.IsNullOrEmpty(name))
                    continue;

                result[profileType] = name;
            }

            return result;
        }

        public Profile GetProfile(ProfileType profileType, ProfileLibrary profileLibrary, bool includeProfileGroup = true)
        {
            if (profileType == ProfileType.Undefined || profileLibrary == null)
                return null;

            string name = GetProfileName(profileType);
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return profileLibrary.GetProfile(name, profileType, includeProfileGroup);
        }

        public IEnumerable<Profile> GetProfiles(ProfileLibrary profileLibrary, bool includeProfileGroup = true)
        {
            return GetProfileDictionary(profileLibrary, includeProfileGroup)?.Values;
        }

        public Dictionary<ProfileType, Profile> GetProfileDictionary(ProfileLibrary profileLibrary, bool includeProfileGroup = true)
        {
            if (profileLibrary == null)
                return null;

            Dictionary<ProfileType, string> dictionary = GetProfileTypeDictionary();
            if (dictionary == null)
                return null;

            Dictionary<ProfileType, Profile> result = new Dictionary<ProfileType, Profile>();
            foreach (KeyValuePair<ProfileType, string> keyValuePair in dictionary)
            {
                Profile profile = profileLibrary.GetProfile(keyValuePair.Value, keyValuePair.Key, includeProfileGroup);
                if (profile == null)
                    continue;

                result[keyValuePair.Key] = profile;
            }

            return result;
        }

        public T GetSystemType<T>(SystemTypeLibrary systemTypeLibrary) where T : ISystemType
        {
            if (systemTypeLibrary == null)
                return default;

            string name = GetSystemTypeName<T>();
            if (name == null)
                return default;

            return systemTypeLibrary.GetSystemTypes<T>(name).FirstOrDefault();
        }

        public override bool FromJObject(JObject jObject)
        {
            if (!base.FromJObject(jObject))
                return false;

            return true;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            if (jObject == null)
                return jObject;

            return jObject;
        }
    }
}
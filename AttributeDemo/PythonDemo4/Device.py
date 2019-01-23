# File Name : Device.py
# Purpose   : To Demonstrate Dynamic Language Support for Python

class HPSystem:

    def _init_(self, id, type, processor):
        self.id = id
        self.type = type
        self.processor = processor

    def GetId(self):
        return self.id

    def GetType(self):
        return self.type

    def GetProcessor(self):
        return self.processor

class HPPrinter:
        
    def _init_(self, id, type):
        self.id = id
        self.type = type

    def GetId(self):
        return self.id

    def GetType(self):
        return self.type

def GetHPSystem(id, type, processors):
    return HPSystem(id, type, processor)

def GetHPSystem(id, type):
    return HPSystem(id, type)
        

